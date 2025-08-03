namespace IniTools.Base.ContentTypes;

/// <summary>
/// Represents a key-value pair from an INI file.
/// </summary>
/// <param name="Key">The key of the setting.</param>
/// <param name="Value">The value of the setting.</param>
public sealed record IniKeyValueContent(string Key, string Value) : IniLineContent;