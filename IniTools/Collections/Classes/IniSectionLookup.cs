using System;
using System.Collections.ObjectModel;
using IniTools.Collections.Interfaces;

namespace IniTools.Collections.Classes;

public class IniSectionLookup() : KeyedCollection< string , IIniSectionList > ( StringComparer.OrdinalIgnoreCase )
{
    protected override string GetKeyForItem ( IIniSectionList item ) { return item.SectionName; }
}
