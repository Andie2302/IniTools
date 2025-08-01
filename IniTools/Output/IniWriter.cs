using System.Collections.Generic;
using System.IO;
using System.Text;
using IniTools.Base.Interfaces;

namespace IniTools.Output
{
    public static class IniWriter
    {
        public static string GetText ( IEnumerable< IIniSection > sections )
        {
            var sb = new StringBuilder();

            foreach ( var section in sections ) {
                sb.AppendLine ( $"[{section.Name}]" );

                foreach ( var element in section.Elements ) {
                    switch ( element ) {
                        case IIniKeyValue kv : sb.AppendLine ( $"{kv.Key}={kv.Value}" ); break;

                        case IIniComment comment : sb.AppendLine ( $";{comment.Comment}" ); break;

                        case IIniEmptyLine : sb.AppendLine(); break;

                        case IIniUnknownLine unknown : sb.AppendLine ( unknown.Line ); break;
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static void Write ( string filePath , IEnumerable< IIniSection > sections ) { File.WriteAllText ( filePath , GetText ( sections ) ); }
    }
}
