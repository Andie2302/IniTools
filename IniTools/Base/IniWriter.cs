using System.Text;
using IniTools.Base.ContentTypes;

namespace IniTools.Base;

public sealed class IniWriter ( WritingSettings? settings = null )
{
    private readonly WritingSettings _settings = settings ?? WritingSettings.Default;

    public void WriteToStream ( IEnumerable< IniLine > lines , Stream stream , Encoding? encoding = null )
    {
        ArgumentNullException.ThrowIfNull ( lines );
        ArgumentNullException.ThrowIfNull ( stream );
        using var writer = new StreamWriter ( stream , encoding ?? Encoding.UTF8 , leaveOpen : true );
        WriteToTextWriter ( lines , writer );
    }

    public void WriteToTextWriter ( IEnumerable< IniLine > lines , TextWriter writer )
    {
        ArgumentNullException.ThrowIfNull ( lines );
        ArgumentNullException.ThrowIfNull ( writer );

        foreach ( var line in lines ) {
            var fullLine = BuildLine ( line );
            writer.WriteLine ( fullLine );
        }
    }

    public string WriteToString ( IEnumerable< IniLine > lines , Encoding? encoding = null )
    {
        ArgumentNullException.ThrowIfNull ( lines );
        using var memoryStream = new MemoryStream();
        WriteToStream ( lines , memoryStream , encoding );
        memoryStream.Position = 0;
        using var reader = new StreamReader ( memoryStream , encoding ?? Encoding.UTF8 );

        return reader.ReadToEnd();
    }

    public void WriteToFile ( IEnumerable< IniLine > lines , string filePath , Encoding? encoding = null )
    {
        ArgumentNullException.ThrowIfNull ( lines );
        ValidateFilePath ( filePath );

        try {
            using var fileStream = new FileStream ( filePath , FileMode.Create , FileAccess.Write , FileShare.None );
            WriteToStream ( lines , fileStream , encoding );
        }
        catch ( IOException ex ) { throw new InvalidOperationException ( $"Failed to write INI file: {filePath}" , ex ); }
    }

    public async Task WriteToFileAsync ( IEnumerable< IniLine > lines , string filePath , Encoding? encoding = null , CancellationToken cancellationToken = default )
    {
        ArgumentNullException.ThrowIfNull ( lines );
        ValidateFilePath ( filePath );

        try {
            var content = WriteToString ( lines , encoding );
            await File.WriteAllTextAsync ( filePath , content , encoding ?? Encoding.UTF8 , cancellationToken );
        }
        catch ( IOException ex ) { throw new InvalidOperationException ( $"Failed to write INI file: {filePath}" , ex ); }
    }

    public static string WriteToString ( IEnumerable< IniLine > lines , WritingSettings? settings = null , Encoding? encoding = null ) { return new IniWriter ( settings ).WriteToString ( lines , encoding ); }
    public static void WriteToFile ( IEnumerable< IniLine > lines , string filePath , WritingSettings? settings = null , Encoding? encoding = null ) { new IniWriter ( settings ).WriteToFile ( lines , filePath , encoding ); }
    public static Task WriteToFileAsync ( IEnumerable< IniLine > lines , string filePath , WritingSettings? settings = null , Encoding? encoding = null , CancellationToken cancellationToken = default ) { return new IniWriter ( settings ).WriteToFileAsync ( lines , filePath , encoding , cancellationToken ); }

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

    private string FormatKeyValue ( IniKeyValueContent kvp ) { return _settings.SpaceAroundSeparator ? $"{kvp.Key} {_settings.KeyValueSeparator} {kvp.Value}" : $"{kvp.Key}{_settings.KeyValueSeparator}{kvp.Value}"; }

    private string CombineContentAndComment ( string contentPart , string? comment )
    {
        if ( string.IsNullOrEmpty ( comment ) ) { return contentPart; }

        if ( string.IsNullOrEmpty ( contentPart ) ) { return comment; }

        var space = _settings.SpaceBeforeComment ? " " : "";

        return $"{contentPart}{space}{comment}";
    }

    private static void ValidateFilePath ( string filePath )
    {
        if ( string.IsNullOrWhiteSpace ( filePath ) ) { throw new ArgumentException ( "File path cannot be null or empty." , nameof ( filePath ) ); }
    }
}
