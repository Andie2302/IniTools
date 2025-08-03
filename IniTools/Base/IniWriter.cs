using System.Text;
using IniTools.Base.ContentTypes;

namespace IniTools.Base;

public static class IniWriter
{
    public static string WriteToString ( List< IniLine > lines )
    {
        var builder = new StringBuilder();

        foreach ( var line in lines ) {
            var contentPart = line.Content switch
            {
                IniSectionContent section => $"[{section.SectionName}]" ,
                IniKeyValueContent kvp => $"{kvp.Key} = {kvp.Value}" ,
                IniUnknownContent unknown => unknown.Text ,
                null => string.Empty ,
                _ => throw new ArgumentOutOfRangeException()
            };

            if ( line.Comment != null ) {
                if ( !string.IsNullOrEmpty ( contentPart ) ) { builder.AppendLine ( $"{contentPart} {line.Comment}" ); }
                else { builder.AppendLine ( line.Comment ); }
            }
            else { builder.AppendLine ( contentPart ); }
        }

        return builder.ToString();
    }
}
