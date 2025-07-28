using IniTools.Interfaces;

namespace IniTools.Classes;

public sealed class IniSection(IIniSectionName? name) : IIniSection
{
    public IIniSectionName? Name { get; } = name;
    public List<IIniListAble> Elements { get; } = [];
}