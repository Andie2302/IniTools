using IniTools.Interfaces;

namespace IniTools.Classes;

public sealed class IniKeyValue(string? key, string? value) : IIniKeyValue
{
    public string? Key { get; set; } = key;
    public string? Value { get; set; } = value;
}