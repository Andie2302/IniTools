using System;
using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

public sealed class IniUnknownLine(string? line) : IIniUnknownLine
{
    public string? Line { get; set; } = line;

    public int CompareTo(IIniUnknownLine? other)
    {
        if (other is null) {
            return 1;
        }

        return string.Compare(Line, other.Line, StringComparison.OrdinalIgnoreCase);
    }

    public bool Equals(IIniUnknownLine? other)
    {
        if (other is null) {
            return false;
        }

        if (ReferenceEquals(this, other)) {
            return true;
        }

        return string.Equals(Line, other.Line, StringComparison.OrdinalIgnoreCase);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as IIniUnknownLine);
    }

    public override int GetHashCode()
    {
        // ToLowerInvariant() für .NET Standard 2.0 Kompatibilität
        return (Line?.ToLowerInvariant() ?? "").GetHashCode();
    }
    
    public static bool operator ==(IniUnknownLine? left, IniUnknownLine? right)
    {
        if (left is null) {
            return right is null;
        }

        return left.Equals(right);
    }

    public static bool operator !=(IniUnknownLine? left, IniUnknownLine? right) => !(left == right);
}
