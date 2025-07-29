namespace IniTools.Base.Enums;

/// <summary>
/// Represents a line in an INI file that is a comment.
/// Typically, this type of line starts with a predefined comment character,
/// such as ';' or '#' depending on the INI file format.
/// </summary>
public enum IniLineTypes
{
    /// <summary
    Comment ,
    /// <summary>
    /// Represents a line in an INI file that contains a key-value pair.
    /// </summary>
    /// <remarks>
    /// A KeyValue line typically consists of a key and an associated value,
    /// separated by an assignment character, such as '=' or ':'.
    /// It is used to store configuration settings in the INI format.
    /// </remarks>
    KeyValue,
    /// <summary>
    /// Represents an unknown or
    Unknown,
    /// <summary>
    /// Represents a line type in an INI file that is empty or contains no content.
    /// </summary>
    Empty
}