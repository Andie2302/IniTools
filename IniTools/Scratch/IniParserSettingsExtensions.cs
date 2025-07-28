namespace IniTools.Scratch;

public static class IniParserSettingsExtensions
{
    public static IniParserSettings WithDefaultValues(this IniParserSettings settings) => settings.WithCommentPrefixes(";", "#").WithKeyValueSeparators("=", ":");
    public static IniParserSettings WithCommentPrefixes(this IniParserSettings settings, params string[] commentPrefixes)
    {
        settings.CommentPrefixes.AddRange(commentPrefixes);
        return settings;
    }
    public static IniParserSettings WithKeyValueSeparators(this IniParserSettings settings, params string[] keyValueSeparators)
    {
        settings.KeyValueSeparators.AddRange(keyValueSeparators);
        return settings;
    }
}