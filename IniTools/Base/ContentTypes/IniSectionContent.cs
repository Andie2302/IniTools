namespace IniTools.Base.ContentTypes;

/// <summary>
/// Represents a section declaration in an INI file.
/// </summary>
/// <param name="SectionName">The name of the section.</param>
public sealed record IniSectionContent(string SectionName) : IniLineContent;