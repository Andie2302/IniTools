using System;
using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

public sealed class IniKeyValue ( string key , string value ) : IIniKeyValue
{
    public string Key { get; set; } = key;
    public string Value { get; set; } = value;

    public int CompareTo ( IIniKeyValue? other )
    {
        if ( other is null ) { return 1; }

        var keyCompare = string.Compare ( Key , other.Key , StringComparison.OrdinalIgnoreCase );

        return keyCompare != 0 ? keyCompare : string.Compare ( Value , other.Value , StringComparison.OrdinalIgnoreCase );
    }

    public bool Equals ( IIniKeyValue? other ) { return other is not null && ( ReferenceEquals ( this , other ) || string.Equals ( Key , other.Key , StringComparison.OrdinalIgnoreCase ) && string.Equals ( Value , other.Value , StringComparison.OrdinalIgnoreCase ) ); }
    public override bool Equals ( object? obj ) { return Equals ( obj as IIniKeyValue ); }
    private const int HashSeed = 17;
    private const int HashMultiplier = 23;

    public override int GetHashCode()
    {
#if NETSTANDARD2_0
        unchecked {
            var hash = HashSeed;
            hash = hash * HashMultiplier + GetStringHashCode ( Key );
            hash = hash * HashMultiplier + GetStringHashCode ( Value );

            return hash;
        }
#else
    return HashCode.Combine(
        GetStringHashCode(Key),
        GetStringHashCode(Value)
    );
#endif
    }

    private static int GetStringHashCode ( string? value ) => StringComparer.OrdinalIgnoreCase.GetHashCode ( value ?? "" );
    public static bool operator == ( IniKeyValue? left , IniKeyValue? right ) { return left is null ? right is null : left.Equals ( right ); }
    public static bool operator != ( IniKeyValue? left , IniKeyValue? right ) => !( left == right );
}
