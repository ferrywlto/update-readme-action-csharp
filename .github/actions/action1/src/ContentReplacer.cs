using System.Text;

public class ContentReplacer {
    private readonly string _context;

    public ContentReplacer(string context) {
        _context = context;
    }
    private int BeginIndex(string phraseToFind) => _context.IndexOf(phraseToFind) + phraseToFind.Length;

    private int EndIndex(string phraseToFind) => _context.LastIndexOf(phraseToFind);

    public string ReplaceContentBetween(string patternBegin, string patternEnd, string newContent) {
        var textBeforeBegin = _context[..BeginIndex(patternBegin)];
        var textAfterEnd = _context[EndIndex(patternEnd)..];
        return Concatenate(textBeforeBegin, newContent, textAfterEnd);
    }

    private static string Concatenate(string prefix, string content, string suffix)
     => new StringBuilder(prefix)
        .Append(Environment.NewLine)
        .Append(content)
        .Append(Environment.NewLine)
        .Append(suffix)
        .ToString();
}
