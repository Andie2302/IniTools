using System.Text;
using IniTools.Base.ContentTypes;

namespace IniTools.Base;

public sealed class IniWriter
{
    private readonly WritingSettings _settings;
    public IniWriter ( WritingSettings? settings = null ) { _settings = settings ?? WritingSettings.Default; }

    public void WriteToStream ( IEnumerable< IniLine > lines , Stream stream )
    {
        ArgumentNullException.ThrowIfNull ( lines );
        ArgumentNullException.ThrowIfNull ( stream );
        using var writer = new StreamWriter ( stream , leaveOpen : true );

        foreach ( var line in lines ) {
            var fullLine = BuildLine ( line );
            writer.WriteLine ( fullLine );
        }
    }

    public string WriteToString ( IEnumerable< IniLine > lines )
    {
        ArgumentNullException.ThrowIfNull ( lines );
        using var memoryStream = new MemoryStream();
        WriteToStream ( lines , memoryStream );
        using var reader = new StreamReader ( memoryStream );

        return reader.ReadToEnd();
    }

    public void WriteToFile ( IEnumerable< IniLine > lines , string filePath )
    {
        ArgumentNullException.ThrowIfNull ( lines );

        if ( string.IsNullOrWhiteSpace ( filePath ) ) { throw new ArgumentException ( "File path cannot be null or empty." , nameof ( filePath ) ); }

        using var fileStream = new FileStream ( filePath , FileMode.Create , FileAccess.Write , FileShare.None );
        WriteToStream ( lines , fileStream );
    }

    public static string WriteToString ( IEnumerable< IniLine > lines , WritingSettings? settings = null ) { return new IniWriter ( settings ).WriteToString ( lines ); }
    public static void WriteToFile ( IEnumerable< IniLine > lines , string filePath , WritingSettings? settings = null ) { new IniWriter ( settings ).WriteToFile ( lines , filePath ); }

    private string BuildLine ( IniLine line )
    {
        var contentPart = FormatContent ( line.Content );

        return CombineContentAndComment ( contentPart , line.Comment );
    }

    private string FormatContent ( IniLineContent? content )
    {
        return content switch
        {
            IniSectionContent section => $"[{section.SectionName}]" ,
            IniKeyValueContent kvp => FormatKeyValue ( kvp ) ,
            IniUnknownContent unknown => unknown.Text ,
            null => string.Empty ,
            _ => throw new ArgumentOutOfRangeException ( nameof ( content ) , content.GetType() , "Unknown content type" )
        };
    }

    private string FormatKeyValue ( IniKeyValueContent kvp )
    {
        var separator = _settings.SpaceAroundSeparator ? $" {_settings.KeyValueSeparator} " : _settings.KeyValueSeparator.ToString();

        return $"{kvp.Key}{separator}{kvp.Value}";
    }

    private string CombineContentAndComment ( string contentPart , string? comment )
    {
        if ( string.IsNullOrEmpty ( comment ) ) { return contentPart; }

        if ( string.IsNullOrEmpty ( contentPart ) ) { return comment; }

        var space = _settings.SpaceBeforeComment ? " " : "";

        return $"{contentPart}{space}{comment}";
    }
}
