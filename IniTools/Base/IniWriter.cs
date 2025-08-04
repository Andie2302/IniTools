using System.Text;
using IniTools.Base.ContentTypes;

namespace IniTools.Base;

public sealed class WritingSettings
{
    public char KeyValueSeparator { get; init; } = '=';
    public bool SpaceAroundSeparator { get; init; } = true;
    public bool SpaceBeforeComment { get; init; } = true;
    public static WritingSettings Default => new WritingSettings();
}

public sealed class IniWriter
{
    private readonly WritingSettings _settings;
    public IniWriter ( WritingSettings? settings = null ) { _settings = settings ?? WritingSettings.Default; }

    public string WriteToString ( IEnumerable< IniLine > lines )
    {
        ArgumentNullException.ThrowIfNull ( lines );
        var builder = new StringBuilder();

        foreach ( var line in lines ) {
            var fullLine = BuildLine ( line );
            builder.AppendLine ( fullLine );
        }

        return builder.ToString();
    }

    public void WriteToFile ( IEnumerable< IniLine > lines , string filePath )
    {
        ArgumentNullException.ThrowIfNull ( lines );

        if ( string.IsNullOrWhiteSpace ( filePath ) ) { throw new ArgumentException ( "File path cannot be null or empty." , nameof ( filePath ) ); }

        var content = WriteToString ( lines );
        File.WriteAllText ( filePath , content );
    }

    public async Task WriteToFileAsync ( IEnumerable< IniLine > lines , string filePath , CancellationToken cancellationToken = default )
    {
        ArgumentNullException.ThrowIfNull ( lines );

        if ( string.IsNullOrWhiteSpace ( filePath ) ) { throw new ArgumentException ( "File path cannot be null or empty." , nameof ( filePath ) ); }

        var content = WriteToString ( lines );
        await File.WriteAllTextAsync ( filePath , content , cancellationToken );
    }

    public static string WriteToString ( IEnumerable< IniLine > lines , WritingSettings? settings )
    {
        ArgumentNullException.ThrowIfNull ( lines );
        ArgumentNullException.ThrowIfNull ( settings );

        return new IniWriter ( settings ).WriteToString ( lines );
    }

    public static void WriteToFile ( IEnumerable< IniLine > lines , string filePath , WritingSettings settings )
    {
        ArgumentNullException.ThrowIfNull ( lines );
        ArgumentNullException.ThrowIfNull ( filePath );
        ArgumentNullException.ThrowIfNull ( settings );
        new IniWriter ( settings ).WriteToFile ( lines , filePath );
    }

    public void WriteToStream ( IEnumerable< IniLine > lines , Stream stream )
    {
        using var writer = new StreamWriter ( stream , leaveOpen : true );

        foreach ( var line in lines ) {
            var fullLine = BuildLine ( line );
            writer.WriteLine ( fullLine );
        }
    }

    private string BuildLine ( IniLine line ) => CombineContentAndComment ( FormatContent ( line.Content ) , line.Comment );

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

    private string FormatKeyValue ( IniKeyValueContent kvp ) => $"{kvp.Key}{( _settings.SpaceAroundSeparator ? $" {_settings.KeyValueSeparator} " : _settings.KeyValueSeparator.ToString() )}{kvp.Value}";

    private string CombineContentAndComment ( string contentPart , string? comment ) => string.IsNullOrEmpty ( comment ) ? contentPart :
        string.IsNullOrEmpty ( contentPart ) ? comment : $"{contentPart}{( _settings.SpaceBeforeComment ? " " : "" )}{comment}";
}
