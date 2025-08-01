using System;
using System.IO;
using IniTools.Base.Classes;
using IniTools.Collections.Classes;

namespace IniTools.Scratch;

public static class IniReader
{
    public static IniSectionCollection Parse ( string filePath )
    {
        var collection = new IniSectionCollection();
        IniSection? currentSection = null;

        foreach ( var line in File.ReadLines ( filePath ) ) {
            var trimmedLine = line.Trim();

            if ( trimmedLine.StartsWith ( "[" , StringComparison.InvariantCultureIgnoreCase ) && trimmedLine.EndsWith ( "]" , StringComparison.InvariantCultureIgnoreCase ) ) {
                var sectionName = trimmedLine.Substring ( 1 , trimmedLine.Length - 2 ).Trim();
                currentSection = new IniSection ( sectionName );
                collection.Add ( currentSection );

                continue;
            }

            if ( currentSection is null ) { continue; }

            if ( string.IsNullOrWhiteSpace ( trimmedLine ) ) { currentSection.AddElement ( new IniEmptyLine() ); }
            else {
                if ( trimmedLine.StartsWith ( ";" , StringComparison.InvariantCultureIgnoreCase ) ) { currentSection.AddElement ( new IniComment ( trimmedLine.Substring ( 1 ) ) ); }
                else {
                    if ( trimmedLine.Contains ( '=' ) ) {
                        var parts = trimmedLine.Split ( [ '=' ] , 2 );
                        currentSection.AddElement ( new IniKeyValue ( parts[0].Trim() , parts[1].Trim() ) );
                    }
                    else { currentSection.AddElement ( new IniUnknownLine ( line ) ); }
                }
            }
        }

        return collection;
    }
}
