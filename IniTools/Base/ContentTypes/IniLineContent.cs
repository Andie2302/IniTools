namespace IniTools.Base.ContentTypes;
/// <summary>
/// Represents the abstract base class for a line of content within an INI file.
/// </summary>
public abstract record IniLineContent;

/// <summary>
/// Represents a key-value pair from an INI file.
/// </summary>
/// <param name="Key">The key of the setting.</param>
/// <param name="Value">The value of the setting.</param>
public sealed record IniKeyValueContent(string Key, string Value) : IniLineContent;

/// <summary>
/// Represents a section declaration in an INI file.
/// </summary>
/// <param name="SectionName">The name of the section.</param>
public sealed record IniSectionContent(string SectionName) : IniLineContent;

/// <summary>
/// Represents a line that could not be parsed as a known INI element, such as a key-value pair or a section.
/// </summary>
/// <param name="Text">The raw text of the unknown line.</param>
public sealed record IniUnknownContent(string Text) : IniLineContent;