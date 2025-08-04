namespace IniTools.Base;

public static class FileUtils
{
    private static readonly string[] LineSeparators = [ "\r\n" , "\r" , "\n" ];
    public static IEnumerable< string > SplitIntoLines ( string content ) => (content??string.Empty).Split ( LineSeparators , StringSplitOptions.None );
    public static bool TestIfFileExists ( string filePath ) => !string.IsNullOrWhiteSpace ( filePath ) && File.Exists ( filePath );
}
