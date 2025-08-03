using System.Text;
using IniTools.Base.ContentTypes;

namespace IniTools.Base;

public class IniWriter
{
    public void Write ( string filePath , List< IniLine > lines )
    {
        var content = WriteToString ( lines );
        File.WriteAllText ( filePath , content );
    }

    public string WriteToString ( List< IniLine > lines )
    {
        var builder = new StringBuilder();

        foreach ( var line in lines ) {
            var contentPart = line.Content switch
            {
                IniSectionContent section => $"[{section.SectionName}]" ,
                IniKeyValueContent kvp => $"{kvp.Key} = {kvp.Value}" ,
                IniUnknownContent unknown => unknown.Text ,
            };

            if ( line.Comment != null ) {
                if ( !string.IsNullOrEmpty ( contentPart ) ) { builder.AppendLine ( $"{contentPart} {line.Comment}" ); }

                {
                    builder.AppendLine ( line.Comment );
                }
            }

            {
                builder.AppendLine ( contentPart );
            }
        }

        return builder.ToString();
    }
}
