using IniTools.Base.ContentTypes;

namespace IniTools.Base;

public static class FileUtils
{
    private static readonly string[] LineSeparators = [ "\r\n" , "\r" , "\n" ];

    public static IEnumerable< string > SplitIntoLines ( string content )
    {
        ArgumentNullException.ThrowIfNull ( content );

        return content.Split ( LineSeparators , StringSplitOptions.None );
    }

    public static void ValidateFileExists ( string filePath )
    {
        if ( string.IsNullOrWhiteSpace ( filePath ) ) { throw new ArgumentException ( "File path cannot be null or empty." , nameof ( filePath ) ); }

        if ( !File.Exists ( filePath ) ) { throw new FileNotFoundException ( $"INI file was not found at path: {filePath}" , filePath ); }
    }
}

public sealed class ParsingSettings
{
    public char[] CommentChars { get; init; } = [ ';' , '#' ];
    public char SectionStartChar { get; init; } = '[';
    public char SectionEndChar { get; init; } = ']';
    public char KeyValueSeparator { get; init; } = '=';
    public static ParsingSettings Default => new ParsingSettings();
}

public sealed class IniParser ( ParsingSettings? settings = null )
{
    private readonly ParsingSettings _settings = settings ?? ParsingSettings.Default;

    public List< IniLine > ParseFile ( string filePath )
    {
        FileUtils.ValidateFileExists ( filePath );

        return ParseLines ( File.ReadLines ( filePath ) );
    }

    public List< IniLine > ParseContent ( string content )
    {
        ArgumentNullException.ThrowIfNull ( content );

        return ParseLines ( FileUtils.SplitIntoLines ( content ) );
    }

    public static List< IniLine > ParseIniFile ( string filePath , ParsingSettings? settings = null )
    {
        var parser = new IniParser ( settings );

        return parser.ParseFile ( filePath );
    }

    public static List< IniLine > ParseContentString ( string content , ParsingSettings? settings = null )
    {
        var parser = new IniParser ( settings );

        return parser.ParseContent ( content );
    }

    private List< IniLine > ParseLines ( IEnumerable< string > rawLines ) { return rawLines.Select ( ParseSingleLine ).ToList(); }

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

    private IniLineContent? CreateContentFromPart ( string contentPart )
    {
        return string.IsNullOrWhiteSpace ( contentPart ) ? null :
            IsSection ( contentPart ) ? CreateSectionContent ( contentPart ) :
            IsKeyValue ( contentPart ) ? CreateKeyValueContent ( contentPart ) : new IniUnknownContent ( contentPart );
    }

    private bool IsSection ( string contentPart ) { return contentPart.Length >= 2 && contentPart.StartsWith ( _settings.SectionStartChar ) && contentPart.EndsWith ( _settings.SectionEndChar ); }
    private bool IsKeyValue ( string contentPart ) { return contentPart.Contains ( _settings.KeyValueSeparator ); }

    private static IniSectionContent CreateSectionContent ( string contentPart )
    {
        var sectionName = contentPart[1..^1].Trim();

        return new IniSectionContent ( sectionName );
    }

    private IniKeyValueContent CreateKeyValueContent ( string contentPart )
    {
        var parts = contentPart.Split ( _settings.KeyValueSeparator , 2 );

        return new IniKeyValueContent ( parts[0].Trim() , parts[1].Trim() );
    }
}
