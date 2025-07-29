using System.Collections.Generic;
using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

public sealed class IniSection : IIniSection
{
    public IniSection ( IIniSectionName? name ) { Name = name; }
    public IniSection ( string name ) : this ( new IniSectionName ( name ) ) { }
    public IIniSectionName? Name { get; }
    public List< IIniListAble > Elements { get; } = [ ];
}
