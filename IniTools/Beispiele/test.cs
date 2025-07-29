using System;
using System.Linq;
using IniTools.Base.Classes;
using IniTools.Base.Interfaces;

namespace IniTools.Scratch;

public static class IniTest
{
    public static void Main() { }

    public static void Test01()
    {
        Console.WriteLine ( "--- IniTools Demo ---" );
        var iniData = new IniData();
        Console.WriteLine ( "\n[AKTION] Setze initiale Werte..." );
        iniData.SetValue ( "Database" , "Host" , "localhost" );
        iniData.SetValue ( "Database" , "Port" , "5432" );
        iniData.SetValue ( "User" , "Name" , "Andreas" );
        iniData.SetValue ( "User" , "Level" , "Admin" );

        if ( iniData.TryGetValue ( "Database" , out var dbSection ) ) {
            dbSection.Elements.Add ( new IniComment ( "; Der Port kann bei Bedarf geändert werden" ) );
            dbSection.Elements.Add ( new IniEmptyLine() );
        }

        Console.WriteLine ( "[AKTION] Ändere den Host..." );
        iniData.SetValue ( "Database" , "Host" , "server.example.com" );
        Console.WriteLine ( "\n[AKTION] Lese Werte aus..." );
        var dbHost = iniData.GetValue ( "Database" , "Host" );
        var userName = iniData.GetValue ( "User" , "Name" );
        var userPassword = iniData.GetValue ( "User" , "Password" );
        Console.WriteLine ( $"  -> Datenbank-Host: {dbHost}" );
        Console.WriteLine ( $"  -> Benutzername: {userName}" );
        Console.WriteLine ( $"  -> Benutzerpasswort: {userPassword ?? "Nicht gefunden"}" );
        Console.WriteLine ( "\n--- Komplette INI-Struktur ---" );
        PrintIniData01 ( iniData );
    }

    public static void Test02()
    {
        Console.WriteLine ( "--- IniTools Fluent API Demo ---" );
        var iniData = new IniData();
        iniData.WithSection ( "Database" ).Set ( "Host" , "localhost" ).Set ( "Port" , "5432" ).WithComment ( "; Der Port kann bei Bedarf geändert werden" ).WithEmptyLine().WithSection ( "User" ).Set ( "Name" , "Andreas" ).Set ( "Level" , "Admin" );
        Console.WriteLine ( "\n[AKTION] INI-Daten mit Fluent API erstellt." );
        iniData.WithSection ( "Database" ).Set ( "Host" , "server.example.com" );
        Console.WriteLine ( "[AKTION] Host geändert." );
        Console.WriteLine ( "\n--- Komplette INI-Struktur ---" );
        PrintIniData02 ( iniData );
        Console.WriteLine ( "\n[AKTION] Lese Werte aus..." );
        var dbHost = iniData.GetValue ( "Database" , "Host" );
        Console.WriteLine ( $"  -> Gelesener Datenbank-Host: {dbHost}" );
    }

    public static void Test03()
    {
        Console.WriteLine ( "--- IniTools 2D-Indexer Demo ---" );
        var iniData = new IniData();
        Console.WriteLine ( "\n[AKTION] Setze Werte mit dem neuen Indexer..." );
        iniData["Database" , "Host"] = "localhost";
        iniData["Database" , "Port"] = "5432";
        iniData["Database" , "User"] = "postgres";
        iniData["User" , "Name"] = "Andreas";
        iniData["Database" , "Host"] = "cloud.server.com";
        Console.WriteLine ( "[AKTION] Host geändert." );
        Console.WriteLine ( "\n[AKTION] Lese Werte mit dem Indexer aus..." );
        var dbHost = iniData["Database" , "Host"];
        var dbPort = iniData["Database" , "Port"];
        Console.WriteLine ( $"  -> Gelesener Datenbank-Host: {dbHost}" );
        Console.WriteLine ( $"  -> Gelesener Datenbank-Port: {dbPort}" );
        Console.WriteLine ( "\n--- Komplette INI-Struktur ---" );
        PrintIniData03 ( iniData );
    }

    private static void PrintIniData01 ( IniData data )
    {
        foreach ( var section in data.Values ) {
            Console.WriteLine ( $"[{section.Name}]" );

            foreach ( var element in section.Elements ) {
                switch ( element ) {
                    case IIniKeyValue kvp : Console.WriteLine ( $"  {kvp.Key} = {kvp.Value}" ); break;

                    case IIniComment comment : Console.WriteLine ( $"  {comment.Comment}" ); break;

                    case IIniEmptyLine : Console.WriteLine(); break;

                    case IIniUnknownLine unknown : Console.WriteLine ( $"  ??? {unknown.Line}" ); break;
                }
            }

            Console.WriteLine();
        }
    }

    private static void PrintIniData02 ( IniData data )
    {
        foreach ( var section in data.Values.OrderBy ( s => s.Name ) ) {
            Console.WriteLine ( $"[{section.Name}]" );

            foreach ( var element in section.Elements ) {
                switch ( element ) {
                    case IIniKeyValue kvp : Console.WriteLine ( $"  {kvp.Key} = {kvp.Value}" ); break;

                    case IIniComment comment : Console.WriteLine ( $"  {comment.Comment}" ); break;

                    case IIniEmptyLine : Console.WriteLine(); break;

                    case IIniUnknownLine unknown : Console.WriteLine ( $"  ??? {unknown.Line}" ); break;
                }
            }

            Console.WriteLine();
        }
    }

    private static void PrintIniData03 ( IniData data )
    {
        foreach ( var section in data.Values.OrderBy ( s => s.Name ) ) {
            Console.WriteLine ( $"[{section.Name}]" );

            foreach ( var element in section.Elements ) {
                if ( element is IIniKeyValue kvp ) { Console.WriteLine ( $"  {kvp.Key} = {kvp.Value}" ); }
            }

            Console.WriteLine();
        }
    }
}
