using System;
using System.Collections.ObjectModel;
using IniTools.Base.Interfaces;

namespace IniTools.Collections.Classes;

public class IniSectionCollection() : KeyedCollection< string , IIniSection > ( StringComparer.OrdinalIgnoreCase )
{
    protected override string GetKeyForItem ( IIniSection item ) { return item.Name; }
}
