using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

public sealed class IniSectionName ( string? name ) : IIniSectionName
{
    private string? _value = name;
    public string? Value
    {
        get => ToSectionKey ( _value );
        set => _value = value;
    }
    public static string ToSectionKey ( string? sectionName ) => sectionName?.Trim() ?? string.Empty;
}
