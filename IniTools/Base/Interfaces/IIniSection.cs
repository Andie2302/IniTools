using System;
using System.Collections.Generic;

namespace IniTools.Base.Interfaces;

public interface IIniSection : IIniElement, IComparable<IIniSection>
{
    IIniSectionName? Name { get; }
    List<IIniListAble> Elements { get; }
}