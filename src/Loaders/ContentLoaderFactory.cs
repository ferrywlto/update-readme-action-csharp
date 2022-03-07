public static class ContentLoaderFactory
{
    public static IContentLoader GetContentLoader(string loaderName)
    {
        var lowerLoaderName = loaderName.ToLower();
        return lowerLoaderName switch
        {
            "medium" => new MediumContentLoader(),
            "stackoverflow" => new StackoverflowContentLoader(),
            _ => throw new ArgumentException($"No loader named: {loaderName}"),
        };
    }
}
