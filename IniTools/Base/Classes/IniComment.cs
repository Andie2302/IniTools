using System;
using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

public sealed class IniComment(string? comment) : IIniComment
{
    public string? Comment { get; set; } = comment;

    public int CompareTo(IIniComment? other) 
    {
        if (other is null) {
            return 1;
        }

        return string.Compare(Comment, other.Comment, StringComparison.OrdinalIgnoreCase);
    }

    public bool Equals(IIniComment? other)
    {
        if (other is null) {
            return false;
        }

        if (ReferenceEquals(this, other)) {
            return true;
        }

        return string.Equals(Comment, other.Comment, StringComparison.OrdinalIgnoreCase);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as IIniComment);
    }

    public override int GetHashCode()
    {
        // ToLowerInvariant() für .NET Standard 2.0 Kompatibilität
        return (Comment?.ToLowerInvariant() ?? "").GetHashCode();
    }
    
    public static bool operator ==(IniComment? left, IniComment? right)
    {
        if (left is null) {
            return right is null;
        }

        return left.Equals(right);
    }

    public static bool operator !=(IniComment? left, IniComment? right) => !(left == right);
}
