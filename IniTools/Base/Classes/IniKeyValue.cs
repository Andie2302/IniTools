using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

public sealed class IniKeyValue(string? key, string? value) : IIniKeyValue
{
    public string? Key { get; set; } = key;
    public string? Value { get; set; } = value;
}