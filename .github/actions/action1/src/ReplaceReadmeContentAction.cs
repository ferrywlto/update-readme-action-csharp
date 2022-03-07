public class ReplaceReadmeContentAction
{
    private readonly List<Step> steps = new();

    public void AddStep(Step config)
    {
        steps.Add(config);
    }

    public async Task<string> Run(string text)
    {
        foreach (var step in steps)
        {
            text = await ExecuteStep(step.Loader, step.Replacer, step.Param, text);
        }
        return text;
    }

    private static async Task<string> ExecuteStep(IContentLoader loader, ContentReplacer replacer, string param, string inputText)
    {
        var newContent = await loader.LoadAndParseContentAsync(param);

        return replacer.ReplaceContentBetweenMarker(inputText, newContent);
    }
}
