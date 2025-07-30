using System;
using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;







public sealed class IniUnknownLine ( string line ) : IIniUnknownLine
{
    
    
    
    
    
    
    
    
    public string Line { get; set; } = line;

    
    
    
    
    
    
    
    
    
    
    
    
    
    
    public int CompareTo ( IIniUnknownLine? other ) { return other is null ? 1 : string.Compare ( Line , other.Line , StringComparison.OrdinalIgnoreCase ); }

    
    
    
    
    
    
    
    
    public bool Equals ( IIniUnknownLine? other ) { return other is not null && ( ReferenceEquals ( this , other ) || string.Equals ( Line , other.Line , StringComparison.OrdinalIgnoreCase ) ); }

    
    
    
    
    
    
    
    
    public override bool Equals ( object? obj ) { return Equals ( obj as IIniUnknownLine ); }

    
    
    
    
    
    
    public override int GetHashCode()
    {
        
        return StringComparer.OrdinalIgnoreCase.GetHashCode(Line ?? "");
    }

    
    
    
    
    
    
    
    
    
    public static bool operator == ( IniUnknownLine? left , IniUnknownLine? right )
    {
        if ( left is null ) { return right is null; }

        return left.Equals ( right );
    }

    
    
    
    
    public static bool operator != ( IniUnknownLine? left , IniUnknownLine? right ) => !( left == right );
}
