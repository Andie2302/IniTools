using System;
using System.Collections.ObjectModel;

namespace IniTools.Scratch.typen;

public class IniSectionLookup() : KeyedCollection< string , IIniSectionList > ( StringComparer.OrdinalIgnoreCase )
{
    protected override string GetKeyForItem ( IIniSectionList item ) { return item.SectionName; }
}
