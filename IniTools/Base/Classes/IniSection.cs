using System.Collections.Generic;
using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

public sealed class IniSection(IIniSectionName? name) : IIniSection
{
    public IIniSectionName? Name { get; } = name;
    public List<IIniListAble> Elements { get; } = [];
}