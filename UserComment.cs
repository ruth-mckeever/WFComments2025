using System.Diagnostics.Contracts;

namespace WFComments2025;

public class UserComment
{
    private string rawComment;
    private string sanitizedComment;

    public string RawComment
    {
        get { return rawComment; }
        set { rawComment = value; }
    }

    public string SanitizedComment
    {
        get { return sanitizedComment; }
        set { sanitizedComment = value; }
    }

    public UserComment(string rawComment)
    {
        this.rawComment = rawComment;
        sanitizedComment = SanitizeService.SanitizeTextJSON(rawComment);
    }
}