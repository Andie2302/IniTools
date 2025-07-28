namespace IniTools.Scratch;

public sealed class IniParserSettings : IIniSettings
{
    public readonly List<string> CommentPrefixes = [];
    public readonly List<string> KeyValueSeparators = [];
    public static IniParserSettings Create => new IniParserSettings();
    public static IniParserSettings Default => Create.WithDefaultValues();
}