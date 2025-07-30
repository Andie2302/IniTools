using System.Collections.Generic;

namespace IniTools.Base.Interfaces;

public interface IIniSection : IIniSortAble< IIniSection > , IIniElement
{
    string Name { get; }
    IReadOnlyList< IIniSectionAddAble > Elements { get; }
}
