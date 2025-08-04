using IniTools.Base.ContentTypes;

namespace IniTools.Base;

public sealed class IniParser ( ParsingSettings? settings = null )
{
    private readonly ParsingSettings _settings = settings ?? ParsingSettings.Default;
    public List< IniLine > ParseFile ( string filePath ) => FileUtils.TestIfFileExists ( filePath ) ? ParseLines ( File.ReadLines ( filePath ) ) : [ ];
    public List< IniLine > ParseContent ( string content ) => ParseLines ( FileUtils.SplitIntoLines ( content ?? string.Empty ) );
    public static List< IniLine > ParseIniFile ( string filePath , ParsingSettings? settings = null ) => new IniParser ( settings ).ParseFile ( filePath );
    public static List< IniLine > ParseContentString ( string content , ParsingSettings? settings = null ) => new IniParser ( settings ).ParseContent ( content );
    private List< IniLine > ParseLines ( IEnumerable< string > rawLines ) => rawLines.Select ( ParseSingleLine ).ToList();
    private IniLine ParseSingleLine ( string rawLine )
    {
        var trimmedLine = rawLine.Trim();
        var (contentPart , commentPart) = SplitLineIntoContentAndComment ( trimmedLine );
        var content = CreateContentFromPart ( contentPart );

        return new IniLine ( content , commentPart );
    }

    private (string content , string? comment) SplitLineIntoContentAndComment ( string rawLine )
    {
        var commentIndex = rawLine.IndexOfAny ( _settings.CommentChars );

        return commentIndex == -1 ? ( rawLine , null ) : ExtractContentAndComment ( rawLine , commentIndex );
    }

    private static (string content , string? comment) ExtractContentAndComment ( string rawLine , int commentIndex )
    {
        var content = rawLine[..commentIndex].Trim();
        var comment = rawLine[commentIndex..].Trim();

        return ( content , string.IsNullOrEmpty ( comment ) ? null : comment );
    }

    private IniLineContent? CreateContentFromPart ( string contentPart ) => string.IsNullOrWhiteSpace ( contentPart ) ? null :
        IsSection ( contentPart ) ? CreateSectionContent ( contentPart ) :
        IsKeyValue ( contentPart ) ? CreateKeyValueContent ( contentPart ) : new IniUnknownContent ( contentPart );

    private bool IsSection ( string contentPart ) => contentPart.Length >= 2 && contentPart.StartsWith ( _settings.SectionStartChar ) && contentPart.EndsWith ( _settings.SectionEndChar );
    private bool IsKeyValue ( string contentPart ) => contentPart.Contains ( _settings.KeyValueSeparator );
    private static IniSectionContent CreateSectionContent ( string contentPart ) => new IniSectionContent ( contentPart[1..^1].Trim() );

    private IniKeyValueContent CreateKeyValueContent ( string contentPart )
    {
        var parts = contentPart.Split ( _settings.KeyValueSeparator , 2 );

        return new IniKeyValueContent ( parts[0].Trim() , parts[1].Trim() );
    }
}
