using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

public sealed class IniComment(string? comment) : IIniComment
{
    public string? Comment { get; set; } = comment;
}
