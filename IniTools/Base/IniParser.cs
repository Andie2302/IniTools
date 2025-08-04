using IniTools.Base.ContentTypes;

namespace IniTools.Base;

public static class IniParser
{
    public static List< IniLine > ParseIniFile ( string filePath )
    {
        if ( !File.Exists ( filePath ) ) { throw new FileNotFoundException ( "Die angegebene INI-Datei wurde nicht gefunden." , filePath ); }

        return ParseLines ( File.ReadLines ( filePath ) );
    }

    public static List< IniLine > ParseContentString ( string content )
    {
        var rawLines = content.Split ( new[] { "\r\n" , "\r" , "\n" } , StringSplitOptions.None );

        return ParseLines ( rawLines );
    }

    private static List< IniLine > ParseLines ( IEnumerable< string > rawLines )
    {
        var lines = new List< IniLine >();
        var commentChars = new[] { ';' , '#' };

        foreach ( var rawLine in rawLines ) {
            var contentPart = rawLine;
            string? commentPart = null;
            var commentIndex = contentPart.IndexOfAny ( commentChars );

            if ( commentIndex != -1 ) {
                commentPart = contentPart[commentIndex..];
                contentPart = contentPart[..commentIndex];
            }

            contentPart = contentPart.Trim();
            IniLineContent? content;

            if ( string.IsNullOrEmpty ( contentPart ) ) { content = null; }
            else {
                if ( contentPart.StartsWith ( '[' ) && contentPart.EndsWith ( ']' ) ) { content = new IniSectionContent ( contentPart[1..^1] ); }
                else {
                    if ( !contentPart.Contains ( '=' ) ) { content = new IniUnknownContent ( contentPart ); }
                    else {
                        var parts = contentPart.Split ( '=' , 2 );
                        content = new IniKeyValueContent ( parts[0].Trim() , parts[1].Trim() );
                    }
                }
            }

            lines.Add ( new IniLine ( content , commentPart ) );
        }

        return lines;
    }
}
