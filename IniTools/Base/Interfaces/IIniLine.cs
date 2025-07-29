namespace IniTools.Base.Interfaces;

/// <summary>
/// Represents a line within an INI file structure. An INI line can be a comment, key-value pair,
/// empty line, or an unknown line. This interface serves as a base abstraction for all types
/// of lines in an INI file.
/// </summary>
public interface IIniLine : IIniElement;

/// <summary>
/// Represents a line in an INI file. This can be a key-value pair, comment, empty line,
/// or any other content within an INI structure.
/// </summary>
/// <remarks>
/// IIniLine serves as a base interface for more specific types of INI lines, such as comments,
/// key-value pairs, empty lines, or unknown lines. This interface provides the structure
/// required for managing and processing different forms of content in an INI file.
/// </remarks>
public interface IIniLine< T > : IIniLine, IIniSortAble< T >;