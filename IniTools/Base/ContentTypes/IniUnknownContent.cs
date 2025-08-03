namespace IniTools.Base.ContentTypes;

/// <summary>
/// Represents a line that could not be parsed as a known INI element, such as a key-value pair or a section.
/// </summary>
/// <param name="Text">The raw text of the unknown line.</param>
public sealed record IniUnknownContent(string Text) : IniLineContent;