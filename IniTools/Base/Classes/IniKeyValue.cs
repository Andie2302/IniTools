using System;
using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

public sealed class IniKeyValue ( string? key , string? value ) : IIniKeyValue
{
    public string? Key { get; set; } = key;
    public string? Value { get; set; } = value;

    public int CompareTo ( IIniKeyValue? other )
    {
        if ( other is null ) {
            return 1;
        }

        var keyCompare = string.Compare ( Key , other.Key , StringComparison.OrdinalIgnoreCase );

        return keyCompare != 0 ? keyCompare : string.Compare ( Value , other.Value , StringComparison.OrdinalIgnoreCase );
    }

    public bool Equals ( IIniKeyValue? other )
    {
        if ( other is null ) {
            return false;
        }

        if ( ReferenceEquals ( this , other ) ) {
            return true;
        }

        return string.Equals ( Key , other.Key , StringComparison.OrdinalIgnoreCase ) && string.Equals ( Value , other.Value , StringComparison.OrdinalIgnoreCase );
    }

    public override bool Equals ( object? obj ) { return Equals ( obj as IIniKeyValue ); }

    public override int GetHashCode()
    {
        // Manuelle Implementierung für .NET Standard 2.0 Kompatibilität
        unchecked // Überlauf ist für Hashcodes beabsichtigt und okay.
        {
            var hash = 17;
            hash = hash * 23 + ( Key?.ToLowerInvariant() ?? "" ).GetHashCode();
            hash = hash * 23 + ( Value?.ToLowerInvariant() ?? "" ).GetHashCode();

            return hash;
        }
    }

    public static bool operator == ( IniKeyValue? left , IniKeyValue? right )
    {
        if ( left is null ) {
            return right is null;
        }

        return left.Equals ( right );
    }

    public static bool operator != ( IniKeyValue? left , IniKeyValue? right ) => !( left == right );
}
