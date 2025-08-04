using System.Text;
using IniTools.Base.ContentTypes;

namespace IniTools.Base;

/// <summary>
/// Configuration settings for INI file writing
/// </summary>
public sealed class WritingSettings
{
    /// <summary>
    /// Character used to separate keys from values
    /// </summary>
    public char KeyValueSeparator { get; init; } = '=';
    /// <summary>
    /// Whether to add spaces around the key-value separator
    /// </summary>
    public bool SpaceAroundSeparator { get; init; } = true;
    /// <summary>
    /// Whether to add a space before comments
    /// </summary>
    public bool SpaceBeforeComment { get; init; } = true;
    /// <summary>
    /// Gets the default writing settings
    /// </summary>
    public static WritingSettings Default => new();
}

/// <summary>
/// Writer for INI files and content
/// </summary>
public sealed class IniWriter
{
    private readonly WritingSettings _settings;

    /// <summary>
    /// Initializes a new instance of the IniWriter class
    /// </summary>
    /// <param name="settings">Writing settings to use</param>
    public IniWriter ( WritingSettings? settings = null ) { _settings = settings ?? WritingSettings.Default; }

    /// <summary>
    /// Converts INI lines to a string representation
    /// </summary>
    /// <param name="lines">The INI lines to convert</param>
    /// <returns>String representation of the INI content</returns>
    /// <exception cref="ArgumentNullException">Thrown when lines is null</exception>
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

    /// <summary>
    /// Writes INI lines to a file
    /// </summary>
    /// <param name="lines">The INI lines to write</param>
    /// <param name="filePath">Path where to write the file</param>
    /// <exception cref="ArgumentNullException">Thrown when lines is null</exception>
    /// <exception cref="ArgumentException">Thrown when filePath is invalid</exception>
    public void WriteToFile ( IEnumerable< IniLine > lines , string filePath )
    {
        ArgumentNullException.ThrowIfNull ( lines );

        if ( string.IsNullOrWhiteSpace ( filePath ) ) { throw new ArgumentException ( "File path cannot be null or empty." , nameof ( filePath ) ); }

        var content = WriteToString ( lines );
        File.WriteAllText ( filePath , content );
    }

    /// <summary>
    /// Writes INI lines to a file asynchronously
    /// </summary>
    /// <param name="lines">The INI lines to write</param>
    /// <param name="filePath">Path where to write the file</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <exception cref="ArgumentNullException">Thrown when lines is null</exception>
    /// <exception cref="ArgumentException">Thrown when filePath is invalid</exception>
    public async Task WriteToFileAsync ( IEnumerable< IniLine > lines , string filePath , CancellationToken cancellationToken = default )
    {
        ArgumentNullException.ThrowIfNull ( lines );

        if ( string.IsNullOrWhiteSpace ( filePath ) ) { throw new ArgumentException ( "File path cannot be null or empty." , nameof ( filePath ) ); }

        var content = WriteToString ( lines );
        await File.WriteAllTextAsync ( filePath , content , cancellationToken );
    }

    /// <summary>
    /// Static method for quick writing with default settings
    /// </summary>
    /// <param name="lines">The INI lines to convert</param>
    /// <param name="settings">Optional writing settings</param>
    /// <returns>String representation of the INI content</returns>
    public static string WriteToString ( IEnumerable< IniLine > lines , WritingSettings? settings )
    {
        ArgumentNullException.ThrowIfNull ( lines );
        ArgumentNullException.ThrowIfNull ( settings );

        return new IniWriter ( settings ).WriteToString ( lines );
    }

    /// <summary>
    /// Static method for quick file writing with default settings
    /// </summary>
    /// <param name="lines">The INI lines to write</param>
    /// <param name="filePath">Path where to write the file</param>
    /// <param name="settings">Optional writing settings</param>
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
