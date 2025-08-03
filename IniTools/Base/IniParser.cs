using IniTools.Base.ContentTypes;

namespace IniTools.Base;

public static class IniParser
{
    public static List< IniLine > Parse ( string filePath )
    {
        if ( !File.Exists ( filePath ) ) { throw new FileNotFoundException ( "FileNotFound:" , filePath ); }

        var lines = new List< IniLine >();
        var commentChars = new[] { ';' , '#' };

        foreach ( var rawLine in File.ReadLines ( filePath ) ) {
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
                    if ( contentPart.Contains ( '=' ) ) {
                        var parts = contentPart.Split ( '=' , 2 );
                        content = new IniKeyValueContent ( parts[0].Trim() , parts[1].Trim() );
                    }
                    else { content = new IniUnknownContent ( contentPart ); }
                }
            }

            lines.Add ( new IniLine ( content , commentPart ) );
        }

        return lines;
    }
}
