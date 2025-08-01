using System.Collections.Generic;
using IniTools.Base.Interfaces;

namespace IniTools.Collections.Interfaces;

public interface IIniSectionContainer
{
    ICollection< IIniSection > Sections { get; }
}
