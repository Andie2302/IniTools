using System.Collections.Generic;

namespace IniTools.Base.Interfaces;

public interface IIniSection : IIniElement
{
    IIniSectionName? Name { get; }
    List<IIniListAble> Elements { get; }
}