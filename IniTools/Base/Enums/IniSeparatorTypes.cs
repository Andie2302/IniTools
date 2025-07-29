namespace IniTools.Base.Enums;

/// <summary>
/// Represents a colon (:) as a key-value separator in INI configuration files.
/// </summary>
public enum IniSeparatorTypes
{
    /// <summary>
    /// Represents the absence of a separator type in the enumeration.
    /// </summary>
    None,
    /// Represents the equals sign (`=`) as a separator type in an INI file.
    /// This separator is commonly used to define key-value pairs in INI file syntax.
    Equals,
    /// <summary>
    /// Represents a colon (:) used as a key-value separator in the enumeration.
    /// </summary>
    Colon
}