using IniTools.Base;

namespace IniTools;

public class Test01
{
    public static void Main()
    {
        Console.WriteLine("Hello World!");
        var file = Path.Combine(Environment.GetFolderPath ( Environment.SpecialFolder.Desktop ), "test.ini");

        if ( File.Exists ( file ) ) {
            Console.WriteLine ( "File exists" );
            var x =IniParser.ParseIniFile ( file );

            foreach ( var line in x ) {
                Console.WriteLine ( line.Content?.ToString() );
            }
        }
        else {
            Console.WriteLine ( "File does not exist" );
        }
    }
}
