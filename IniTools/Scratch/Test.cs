using System;
using System.IO;
using IniTools.Output;

namespace IniTools.Scratch;

public class IniTest
{
    public static void Main()
    {
        var desktopPath = Environment.GetFolderPath ( Environment.SpecialFolder.Desktop );
        var pfad = Path.Combine ( desktopPath , "test.ini" );
        var x = IniReader.Parse ( pfad );
        Console.WriteLine ( "--- INI-File Content ---" );
        var text = IniWriter.GetText ( x );
        Console.WriteLine ( text );
        Console.WriteLine();
    }
}
