using System;
using System.Collections.Generic;
using IniTools.Base.Interfaces;
using IniTools.Scratch;

namespace IniTools.Base.Classes;

public sealed class IniSection ( IIniSectionName? name ) : IIniSection
{
    public IIniSectionNameComparer Comparer = new IniSectionNameComparer();
    public IniSection(string name) : this(new IniSectionName(name)) { }
    public IIniSectionName? Name { get; } = name;
    public List<IIniListAble> Elements { get; } = [];
    #region Vereinfachte Vergleichs- und Gleichheitsimplementierung
    /// <summary>
    /// Vergleicht diese Sektion mit einer anderen für die Sortierung (basiert auf dem Namen).
    /// </summary>
    public int CompareTo(IIniSection? other)
    {
        if (other is null) {
            return 1;
        }
        var comparer = new IniSectionNameComparer();
        return comparer.Equals(this.Name, other.Name) ? 0 : string.Compare(this.Name?.Value, other.Name?.Value, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Prüft auf Gleichheit mit einer anderen Sektion (nur basierend auf dem Namen).
    /// </summary>
    public bool Equals(IIniSection? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return new IniSectionNameComparer().Equals(this.Name, other.Name);
    }

    /// <summary>
    /// Überschreibt die Basis-Equals-Methode.
    /// </summary>
    public override bool Equals(object? obj)
    {
        return Equals(obj as IIniSection);
    }

    /// <summary>
    /// Gibt einen Hashcode für die Sektion zurück (nur basierend auf dem Namen).
    /// </summary>
    public override int GetHashCode()
    {
        return new IniSectionNameComparer().GetHashCode(Name ?? new IniSectionName(null));
    }

    public static bool operator ==(IniSection? left, IniSection? right)
    {
        if (left is null)
        {
            return right is null;
        }
        return left.Equals(right);
    }

    public static bool operator !=(IniSection? left, IniSection? right) => !(left == right);

    #endregion
}