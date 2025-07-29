namespace IniTools.Base.Interfaces;

/// <summary>
/// Represents a line in an INI file for which the type of content is unknown or unrecognized.
/// </summary>
/// <remarks>
/// This interface is used to handle lines in an INI structure that do not follow standard formats
/// such as key-value pairs, comments, or empty lines. It provides a mechanism to store and manage
/// such lines without discarding their content.
/// IIniUnknownLine inherits from IIniLine and IIniSectionAddAble, allowing it to be managed
/// within an INI structure and enabling additional behavior suitable for section-oriented processing.
/// </remarks>
public interface IIniUnknownLine : IIniLine< IIniUnknownLine > , IIniSectionAddAble
{
    /// <summary>
    /// Represents an unknown or unclassified line within an INI file structure.
    /// This property holds the raw string content of the unrecognized line
    /// as it appears in the INI file.
    /// </summary>
    string Line { get; set; }
}
