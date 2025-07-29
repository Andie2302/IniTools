using System;
using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

/// <summary>
/// Represents a line from an INI file whose purpose cannot be identified or categorized as a known type of INI line.
/// </summary>
/// <remarks>
/// This class implements the <see cref="IIniUnknownLine"/> interface and provides a way to store and compare unknown lines from INI files.
/// </remarks>
public sealed class IniUnknownLine ( string line ) : IIniUnknownLine
{
    /// <summary>
    /// Gets or sets the content of the line in an INI file.
    /// </summary>
    /// <remarks>
    /// Represents the raw text content of a line whose type or structure is unknown within the context
    /// of an INI file. This property allows retaining and managing such unrecognized lines for inclusion
    /// in the INI structure without transformation or interpretation.
    /// </remarks>
    public string Line { get; set; } = line;

    /// <summary>
    /// Compares the current instance with another IIniUnknownLine object and returns an integer
    /// that indicates whether the current instance precedes, follows, or occurs in the same position
    /// in the sort order as the other object.
    /// </summary>
    /// <param name="other">The IIniUnknownLine instance to compare with this object. It can be null.</param>
    /// <returns>
    /// A signed integer that indicates the relative order of the objects being compared:
    /// <list type="bullet">
    /// <item>A value less than zero indicates that this instance precedes the other object in the sort order.</item>
    /// <item>A value of zero indicates that this instance occurs in the same position as the other object in the sort order.</item>
    /// <item>A value greater than zero indicates that this instance follows the other object in the sort order or the other object is null.</item>
    /// </list>
    /// </returns>
    public int CompareTo ( IIniUnknownLine? other ) { return other is null ? 1 : string.Compare ( Line , other.Line , StringComparison.OrdinalIgnoreCase ); }

    /// <summary>
    /// Determines whether the current instance is equal to another object of type <see cref="IIniUnknownLine"/>.
    /// </summary>
    /// <param name="other">The <see cref="IIniUnknownLine"/> to compare with the current instance.</param>
    /// <returns>
    /// <c>true</c> if the current instance and the specified <see cref="IIniUnknownLine"/> have equivalent content;
    /// otherwise, <c>false</c>.
    /// </returns>
    public bool Equals ( IIniUnknownLine? other ) { return other is not null && ( ReferenceEquals ( this , other ) || string.Equals ( Line , other.Line , StringComparison.OrdinalIgnoreCase ) ); }

    /// <summary>
    /// Determines whether the specified object is equal to the current instance of the object.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns>
    /// Returns <c>true</c> if the specified object is of type <see cref="IIniUnknownLine"/> and its line content
    /// matches the current instance's line content in a case-insensitive manner; otherwise, <c>false</c>.
    /// </returns>
    public override bool Equals ( object? obj ) { return Equals ( obj as IIniUnknownLine ); }

    /// <summary>
    /// Serves to generate a hash code for an instance of the IniUnknownLine class.
    /// </summary>
    /// <returns>
    /// An integer representing the hash code, derived from the lower-cased value of the Line property.
    /// </returns>
    public override int GetHashCode()
    {
        return ( Line?.ToLowerInvariant() ?? "" ).GetHashCode();
    }

    /// <summary>
    /// Defines the equality comparison operator. Determines whether two instances of IniUnknownLine are equal.
    /// </summary>
    /// <param name="left">The first IniUnknownLine to compare.</param>
    /// <param name="right">The second IniUnknownLine to compare.</param>
    /// <returns>
    /// True if the two instances are equal; otherwise, false.
    /// Returns true if both are null. If one is null and the other is not, returns false.
    /// </returns>
    public static bool operator == ( IniUnknownLine? left , IniUnknownLine? right )
    {
        if ( left is null ) { return right is null; }

        return left.Equals ( right );
    }

    /// Defines the equality and inequality operators for comparing instances of IniUnknownLine.
    /// The equality operator (==) compares two instances of IniUnknownLine for equivalence,
    /// while the inequality operator (!=) determines whether two instances are not equivalent.
    /// Both operators utilize the `Equals` method for performing their comparisons.
    public static bool operator != ( IniUnknownLine? left , IniUnknownLine? right ) => !( left == right );
}
