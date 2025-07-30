using System;
using System.Collections.Generic;

namespace IniTools.Scratch;

public static class IniProgram
{
    public static void Main()
    {
        var dictionarySpeicher = new Dictionary< string , IniSection? >();
        IIniRepository< string , IniSection? > iniRepo = new IniDictionaryRepository< string , IniSection? > ( dictionarySpeicher );
        var section1 = new IniSection { Name = "Database" , Content = "user=admin" };
        iniRepo.TryAdd ( section1 , out _ );
        Console.WriteLine ( $"Anzahl der Sektionen: {iniRepo.Count}" );
        Console.WriteLine ( "Ändere Schlüssel von 'Database' zu 'DB_Legacy'..." );
        iniRepo.TryUpdateKey ( "Database" , "DB_Legacy" , out _ );
        Console.WriteLine ( iniRepo.TryGetValue ( "Database" , out _ ) ? "Fehler: Sektion immer noch unter altem Schlüssel gefunden!" : "Korrekt: Sektion unter altem Schlüssel nicht mehr gefunden." );

        if ( iniRepo.TryGetValue ( "DB_Legacy" , out var gefundeneSektion ) ) {
            Console.WriteLine ( $"Erfolg: Sektion unter neuem Schlüssel gefunden: {gefundeneSektion}" );
            Console.WriteLine ( $"Name im Objekt selbst ist jetzt: '{gefundeneSektion?.Name}'" );
        }
        else { Console.WriteLine ( "Fehler: Sektion wurde nicht unter neuem Schlüssel gefunden!" ); }
    }
}
