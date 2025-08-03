using IniTools.Base.ContentTypes;

namespace IniTools.Base;

public class IniParser
{
    public static List< IniLine > Parse ( string filePath )
    {
        if ( !File.Exists ( filePath ) ) { throw new FileNotFoundException ( "Die angegebene INI-Datei wurde nicht gefunden." , filePath ); }

        var lines = new List< IniLine >();
        var commentChars = new[] { ';' , '#' };

        foreach ( var rawLine in File.ReadLines ( filePath ) ) {
            var contentPart = rawLine;
            string? commentPart = null;

            // 1. Kommentar vom Inhalt trennen
            var commentIndex = contentPart.IndexOfAny ( commentChars );

            if ( commentIndex != -1 ) {
                commentPart = contentPart[commentIndex..];
                contentPart = contentPart[..commentIndex];
            }

            contentPart = contentPart.Trim();

            // 2. Inhalt analysieren und das passende Content-Objekt erstellen
            IniLineContent? content;

            if ( string.IsNullOrEmpty ( contentPart ) ) {
                // Wenn nach dem Abtrennen des Kommentars nichts übrig bleibt,
                // ist der Inhalt null. Die Zeile ist also eine reine Kommentar- oder Leerzeile.
                content = null;
            }
            else {
                if ( contentPart.StartsWith ( '[' ) && contentPart.EndsWith ( ']' ) ) { content = new IniSectionContent ( contentPart[1..^1] ); }
                else {
                    if ( contentPart.Contains ( '=' ) ) {
                        var parts = contentPart.Split ( '=' , 2 );
                        content = new IniKeyValueContent ( parts[0].Trim() , parts[1].Trim() );
                    }
                    else {
                        // Alles andere ist unbekannter Inhalt (z.B. eine fehlerhafte Zeile)
                        content = new IniUnknownContent ( contentPart );
                    }
                }
            }

            // 3. Das finale IniLine-Objekt erstellen und zur Liste hinzufügen
            lines.Add ( new IniLine ( content , commentPart ) );
        }

        return lines;
    }
}
