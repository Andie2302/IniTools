using System;
using System.Collections.Generic;
using IniTools.Base.Classes;
using IniTools.Base.Interfaces;

namespace IniTools.Scratch;

public interface IIniSectionNameComparer : IEqualityComparer< IIniSectionName >;
public class IniSectionNameComparer : IIniSectionNameComparer
{
    public bool Equals(IIniSectionName? x, IIniSectionName? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null || y is null) return false;

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