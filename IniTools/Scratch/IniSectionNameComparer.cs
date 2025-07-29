using System;
using System.Collections.Generic;
using IniTools.Base.Classes;
using IniTools.Base.Interfaces;

public class IniSectionNameComparer : IEqualityComparer<IIniSectionName>
{
    public bool Equals(IIniSectionName? x, IIniSectionName? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null || y is null) return false;

        // Wir verwenden die Logik aus deiner IniSectionName-Klasse, um die Werte zu vergleichen.
        var keyX = IniSectionName.ToSectionKey(x.Value);
        var keyY = IniSectionName.ToSectionKey(y.Value);

        return string.Equals(keyX, keyY, StringComparison.OrdinalIgnoreCase);
    }

    public int GetHashCode(IIniSectionName? obj)
    {
        var key = IniSectionName.ToSectionKey(obj?.Value??string.Empty);
        return key.GetHashCode();
    }
}
