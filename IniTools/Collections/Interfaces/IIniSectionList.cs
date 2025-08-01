using IniTools.Base.Interfaces;
using IniTools.Collections.Enums;

namespace IniTools.Collections.Interfaces;

public interface IIniSectionList : IIniSectionContainer
{
    string SectionName { get; }
    bool IsGlobal { get; }
    bool TryAdd ( IIniSection item , out IniSetItemErrors error );
}
