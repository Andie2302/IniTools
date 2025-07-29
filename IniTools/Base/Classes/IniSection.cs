using System;
using System.Collections.Generic;
using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

/// <summary>
/// Represents a section in an INI configuration file. The <see cref="IniSection"/> class
/// provides functionality for storing the name of the section and its associated elements,
/// and it supports operations such as comparison, equality checks, and hash code generation.
/// </summary>
public sealed class IniSection ( string name ) : IIniSection
{
    /// <summary>
    /// Gets the name of the INI section.
    /// </summary>
    /// <remarks>
    /// The name uniquely identifies the section within an INI configuration file.
    /// It is case-insensitive and may not contain leading or trailing whitespace.
    /// </remarks>
    public string Name { get; } = name;
    /// <summary>
    /// Gets the collection of elements contained within the current INI section.
    /// </summary>
    /// <remarks>
    /// This property provides access to the list of elements that belong to the specific INI section.
    /// Each element adheres to the <see cref="IIniSectionAddAble"/> interface, allowing various types
    /// of INI components (such as key-value pairs, comments, and empty lines) to coexist within the section.
    /// </remarks>
    public List< IIniSectionAddAble > Elements { get; } = [ ];

    /// <summary>
    /// Converts the given section name to a normalized key representation by trimming
    /// whitespace. If the provided section name is null, an empty string is returned.
    /// </summary>
    /// <param name="sectionName">The name of the section to convert. Can be null.</param>
    /// <returns>A trimmed and normalized version of the section name, or an empty string if the input is null.</returns>
    private static string ToSectionKey ( string? sectionName ) => sectionName?.Trim() ?? string.Empty;

    /// <summary>
    /// Compares the current <see cref="IniSection"/> instance with another <see cref="IIniSection"/>.
    /// </summary>
    /// <param name="other">The other <see cref="IIniSection"/> instance to compare to.</param>
    /// <returns>
    /// A signed integer that indicates the relative order of the objects being compared.
    /// The return value has these meanings:
    /// <list type="table">
    /// <item><description>Less than zero: This instance precedes the other instance in the sort order.</description></item>
    /// <item><description>Zero: This instance occurs in the same position in the sort order as the other instance.</description></item>
    /// <item><description>Greater than zero: This instance follows the other instance in the sort order.</description></item>
    /// </list>
    /// </returns>
    public int CompareTo ( IIniSection? other ) { return other is null ? 1 : string.Compare ( ToSectionKey ( Name ) , ToSectionKey ( other.Name ) , StringComparison.OrdinalIgnoreCase ); }

    /// <summary>
    /// Determines whether the current <see cref="IniSection"/> instance is equal to another specified <see cref="IIniSection"/>.
    /// </summary>
    /// <param name="other">The <see cref="IIniSection"/> instance to compare with the current instance, or <c>null</c> for no comparison.</param>
    /// <returns>
    /// <c>true</c> if the current instance is equal to the specified instance; otherwise, <c>false</c>.
    /// </returns>
    public bool Equals ( IIniSection? other ) { return other is not null && ( ReferenceEquals ( this , other ) || string.Equals ( ToSectionKey ( Name ) , ToSectionKey ( other.Name ) , StringComparison.OrdinalIgnoreCase ) ); }

    /// <summary>
    /// Determines whether the specified object is equal to the current instance.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns>
    /// <c>true</c> if the specified object is equal to the current instance; otherwise, <c>false</c>.
    /// </returns>
    public override bool Equals ( object? obj ) { return Equals ( obj as IIniSection ); }

    /// <summary>
    /// Computes the hash code for the current <see cref="IniSection"/> instance.
    /// The hash code is based on the section key derived from the section name.
    /// </summary>
    /// <returns>
    /// An integer hash code representing the current instance.
    /// </returns>
    public override int GetHashCode() { return ToSectionKey ( Name ).GetHashCode(); }

    /// <summary>
    /// Determines whether two specified <see cref="IniSection"/> objects are equal.
    /// </summary>
    /// <param name="left">The first <see cref="IniSection"/> to compare.</param>
    /// <param name="right">The second <see cref="IniSection"/> to compare.</param>
    /// <returns>
    /// <c>true</c> if the two <see cref="IniSection"/> objects are equal; otherwise, <c>false</c>.
    /// </returns>
    public static bool operator == ( IniSection? left , IniSection? right ) { return left is null ? right is null : left.Equals ( right ); }

    /// <summary>
    /// Defines the inequality operator (!=) for comparing two IniSection instances.
    /// Returns true if the two IniSection instances are not equal; otherwise, false.
    /// </summary>
    /// <param name="left">The first IniSection to compare, or null.</param>
    /// <param name="right">The second IniSection to compare, or null.</param>
    /// <returns>
    /// True if the two IniSection instances are not equal; otherwise, false.
    /// Two sections are considered equal if their names, after being formatted with
    /// <see cref="ToSectionKey"/>, are equivalent in a case-insensitive comparison.
    /// </returns>
    public static bool operator != ( IniSection? left , IniSection? right ) => !( left == right );
}
