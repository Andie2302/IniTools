using System;

namespace IniTools.Scratch;

public class test
{
    public static void Main()
    {
        var iniData = new IniData();
        var b = iniData.TryGetValue ( "peter" , out var a);
        Console.Out.WriteLine(b);
    }
}
