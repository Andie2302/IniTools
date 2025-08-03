using IniTools.Base.ContentTypes;

namespace IniTools.Base;

public sealed class IniLine ( IniLineContent? content , string? comment )
{
    public IniLineContent? Content { get; } = content;
    public string? Comment { get; } = comment;
}