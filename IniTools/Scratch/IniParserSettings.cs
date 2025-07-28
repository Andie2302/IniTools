using System.Collections;
using IniTools.Classes;
using IniTools.Interfaces;

namespace IniTools.Scratch;



public interface IIniSettings;
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

public sealed class IniParserSettings : IIniSettings
{
    public readonly List<string> CommentPrefixes = [];
    public readonly List<string> KeyValueSeparators = [];
    public static IniParserSettings CreateEmpty => new IniParserSettings();
    public static IniParserSettings CreateDefault => CreateEmpty.WithDefaultValues();
}
public sealed class IniData : IIniElement, IEnumerable<IIniSection>
{
    private readonly List<IIniSection> _sections = [];
    public void Add(IIniSection section) => _sections.Add(section);
    public IEnumerator<IIniSection> GetEnumerator() => _sections.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public static class KA
{
    public static IniData Parse(string content, IniParserSettings? settings = null)
    {
        settings ??= IniParserSettings.CreateDefault;
        var iniData = new IniData();
        IniSection? currentSection = null;
        var lines = content.Split(["\r\n", "\r", "\n"], StringSplitOptions.None);
        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();
            if (string.IsNullOrEmpty(trimmedLine)) { }
            else if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]")) { }
            else if (settings.CommentPrefixes.Any(prefix => trimmedLine.StartsWith(prefix))) { }
        }

        return iniData;
    }
}