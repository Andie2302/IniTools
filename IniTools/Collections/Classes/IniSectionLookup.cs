using System;
using System.Collections.ObjectModel;

namespace IniTools.Collections.Classes;

public class IniSectionLookup() : KeyedCollection< string , IniSectionList > ( StringComparer.OrdinalIgnoreCase )
{
    protected override string GetKeyForItem ( IniSectionList item ) => item.SectionName;
}
