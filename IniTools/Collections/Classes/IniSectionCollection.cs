using System;
using System.Collections.ObjectModel;
using IniTools.Collections.Interfaces;
using IIniSection = IniTools.Base.Interfaces.IIniSection;

namespace IniTools.Collections.Classes;

public class IniSectionCollection() : KeyedCollection< string , IIniSection > ( StringComparer.OrdinalIgnoreCase ) , IIniSectionCollection
{
    protected override string GetKeyForItem ( IIniSection item ) { return item.Name; }
}
