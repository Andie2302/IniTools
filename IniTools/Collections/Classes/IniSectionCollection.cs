using System;
using System.Collections.ObjectModel;
using IniTools.Base.Interfaces;

namespace IniTools.Scratch.typen;

public class IniSectionCollection() : KeyedCollection< string , IIniSection > ( StringComparer.OrdinalIgnoreCase ) , IIniSectionCollection
{
    protected override string GetKeyForItem ( IIniSection item ) { return item.Name; }
}
