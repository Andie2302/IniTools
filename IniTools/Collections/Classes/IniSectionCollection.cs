using System;
using System.Collections.ObjectModel;
using IniTools.Base.Interfaces;
using IniTools.Collections.Interfaces;

namespace IniTools.Collections.Classes;

public class IniSectionCollection() : KeyedCollection< string , IIniSection > ( StringComparer.OrdinalIgnoreCase ) , IIniSectionCollection
{
    protected override string GetKeyForItem ( IIniSection item ) { return item.Name; }
}
