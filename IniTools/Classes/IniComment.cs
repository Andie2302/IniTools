using IniTools.Interfaces;

namespace IniTools.Classes;

public sealed class IniComment(string? comment) : IIniComment
{
    public string? Comment { get; set; } = comment;
}