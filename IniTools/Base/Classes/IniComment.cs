using System;
using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

/// <summary>
/// Represents a comment within an INI file.
/// </summary>
/// <remarks>
/// The <see cref="IniComment"/> class encapsulates a comment line in an INI file.
/// Comments are typically used for descriptive or informational purposes within a configuration file.
/// </remarks>
public sealed class IniComment ( string comment ) : IIniComment
{
    /// <summary>
    /// Gets or sets the textual content of the INI comment.
    /// </summary>
    /// <remarks>
    /// The Comment property represents the text of a comment line within an INI file.
    /// Comments are commonly used to add descriptive notes or explanations in INI files.
    /// </remarks>
    public string Comment { get; set; } = comment;

    /// <summary>
    /// Compares the current <see cref="IIniComment"/> instance with another <see cref="IIniComment"/> instance
    /// to determine their relative order in a case-insensitive manner.
    /// </summary>
    /// <param name="other">
    /// An <see cref="IIniComment"/> object to compare against the current instance.
    /// </param>
    /// <returns>
    /// An integer indicating the lexical relationship between the current instance and the specified <see cref="IIniComment"/>:
    /// - Returns a value less than 0 if this instance precedes <paramref name="other"/>.
    /// - Returns 0 if both instances are equal in lexical comparison.
    /// - Returns a value greater than 0 if this instance follows <paramref name="other"/>.
    /// </returns>
    public int CompareTo ( IIniComment? other ) { return other is null ? 1 : string.Compare ( Comment , other.Comment , StringComparison.OrdinalIgnoreCase ); }

    /// <summary>
    /// Determines whether the current instance is equal to another instance of <see cref="IIniComment"/>.
    /// </summary>
    /// <param name="other">The instance of <see cref="IIniComment"/> to compare with the current instance.</param>
    /// <returns>
    /// True if the current instance is equal to the specified instance; otherwise, false.
    /// </returns>
    public bool Equals ( IIniComment? other ) { return other is not null && ( ReferenceEquals ( this , other ) || string.Equals ( Comment , other.Comment , StringComparison.OrdinalIgnoreCase ) ); }

    /// <summary>
    /// Determines whether the specified object is equal to the current <see cref="IniComment"/> instance.
    /// </summary>
    /// <param name="obj">The object to compare with the current <see cref="IniComment"/> instance.</param>
    /// <returns>
    /// true if the specified object is equal to the current <see cref="IniComment"/> instance; otherwise, false.
    /// </returns>
    public override bool Equals ( object? obj ) { return Equals ( obj as IIniComment ); }

    /// <summary>
    /// Generates a hash code for the current instance using the value of the comment.
    /// The hash code is derived from a case-insensitive representation of the comment string.
    /// </summary>
    /// <returns>
    /// An integer representing the hash code of the comment.
    /// </returns>
    public override int GetHashCode() { return ( Comment.ToLowerInvariant() ?? "" ).GetHashCode(); }

    /// <summary>
    /// Defines equality and inequality operators for IniComment objects.
    /// </summary>
    /// <param name="left">The left-hand IniComment object to compare.</param>
    /// <param name="right">The right-hand IniComment object to compare.</param>
    /// <returns>
    /// A boolean value indicating whether the two IniComment objects are considered equal
    /// based on their contents.
    /// </returns>
    public static bool operator == ( IniComment? left , IniComment? right ) { return left is null ? right is null : left.Equals ( right ); }

    /// <summary>
    /// Defines inequality operator for comparing two <see cref="IniComment"/> instances.
    /// </summary>
    /// <param name="left">The left <see cref="IniComment"/> instance to compare.</param>
    /// <param name="right">The right <see cref="IniComment"/> instance to compare.</param>
    /// <returns>
    /// Returns <c>true</c> if the two <see cref="IniComment"/> instances are not equal; otherwise, <c>false</c>.
    /// </returns>
    public static bool operator != ( IniComment? left , IniComment? right ) => !( left == right );
}
