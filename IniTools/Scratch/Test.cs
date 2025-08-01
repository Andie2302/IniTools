using System;
using System.IO;
using IniTools.Base.Interfaces;

namespace IniTools.Scratch;

public class IniTest
{
    public static void Main()
    {
        var desktopPath = Environment.GetFolderPath ( Environment.SpecialFolder.Desktop );
        var pfad = Path.Combine ( desktopPath , "test.ini" );
        var x = IniFileParser.Parse ( pfad );
        Console.WriteLine ( "--- INI-File Content ---" );

        foreach ( var section in x ) {
            Console.WriteLine ( $"[{section.Name}]" );

            foreach ( var element in section.Elements ) {
                switch ( element ) {
                    case IIniKeyValue kv : Console.WriteLine ( $"{kv.Key} = {kv.Value}" ); break;

                    case IIniComment comment : Console.WriteLine ( $";{comment.Comment}" ); break;

                    case IIniEmptyLine : Console.WriteLine(); break;

                    case IIniUnknownLine unknown : Console.WriteLine ( $"?? {unknown.Line}" ); break;
                }
            }

            Console.WriteLine();
        }
    }
}
