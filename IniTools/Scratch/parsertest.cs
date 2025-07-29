using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IniTools.Scratch;

public class Scratch
{
    private static readonly string[] LineBreaks = ["\r\n", "\r", "\n"];
    public static List<string> GetLines(string filePath) => ProcessTextIntoLines(File.ReadAllText(filePath));
    private static List<string> ProcessTextIntoLines(string text) => text.Split(LineBreaks, StringSplitOptions.None).Select(line => line.Trim()).ToList();
    public static void Main()
    {
        Console.WriteLine("Hello World!");
       List<string> lines = GetLines(@"C:\Users\Andreas\AppData\Roaming\Mozilla\Firefox\profiles.ini");
       foreach (var line in lines)
           Console.WriteLine(line);
    }
}