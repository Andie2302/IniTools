using System;
using System.Collections.ObjectModel;
using IniTools.Collections.Interfaces;

namespace IniTools.Collections.Classes;

public class IniSectionLookup() : KeyedCollection< string , IniSectionList > ( StringComparer.OrdinalIgnoreCase ) , IIniSectionLookup
{
    protected override string GetKeyForItem ( IniSectionList item ) => item.SectionName;
}
