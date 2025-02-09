using System.Text;

public class ContentReplacer(string identifier)
{
    private static string _markerPattern = "<!-- {0}:{1} -->";
    private static string _markerStartText = "START";
    private static string _markerEndText = "END";
    private readonly string _identifier = identifier;

    public static void SetMarkerPattern(string pattern, string startText = "START", string endText = "END")
    {
        _markerPattern = pattern;
        _markerStartText = startText;
        _markerEndText = endText;
    }

    public string ReplaceContentBetweenMarker(string text, string newContent)
    => Concatenate(TextBeforeMarker(text), newContent, TextAfterMarker(text));

    private static string Concatenate(string prefix, string content, string suffix)
     => new StringBuilder(prefix)
        .Append(Environment.NewLine)
        .Append(content)
        .Append(Environment.NewLine)
        .Append(suffix)
        .ToString();
    private string TextBeforeMarker(string text) => text[..BeginIndex(text, BeginMarker)];
    private string TextAfterMarker(string text) => text[EndIndex(text, EndMarker)..];
    private string BeginMarker => string.Format(_markerPattern, _identifier, _markerStartText);
    private string EndMarker => string.Format(_markerPattern, _identifier, _markerEndText);
    private static int BeginIndex(string text, string phraseToFind) => text.IndexOf(phraseToFind) + phraseToFind.Length;
    private static int EndIndex(string text, string phraseToFind) => text.LastIndexOf(phraseToFind);

}
