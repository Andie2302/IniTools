using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

public sealed class IniSectionName(string? name) : IIniSectionName
{
    public string? Name { get; set; } = name;
}