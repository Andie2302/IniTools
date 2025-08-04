namespace IniTools.Base;

public sealed class WritingSettings
{
    public char KeyValueSeparator { get; init; } = '=';
    public bool SpaceAroundSeparator { get; init; } = true;
    public bool SpaceBeforeComment { get; init; } = true;
    public static WritingSettings Default => new WritingSettings();
}