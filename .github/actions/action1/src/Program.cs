Console.WriteLine($"args: {args.Length}");
if(args.Length > 0) {
    if(File.Exists(args[0]))
    {
        var fileName = args[0];
        var soUserId = int.Parse(args[1]);
        // var fileInfo = new FileInfo(args[0]);
        // Console.WriteLine($"File: {fileInfo.FullName}");
        var text = File.ReadAllText(fileName);
        // Console.WriteLine($"Content:");
        // Console.WriteLine(text);
        // var newText = text.Replace("CODE", "MAID");
        // File.WriteAllText(args[0], newText);

        var startPhrase = "<!-- BLOG-POST-LIST:START -->";
        var endPhrase = "<!-- BLOG-POST-LIST:END -->";
        var replacer = new ContentReplacer(text);

        var soLoader = new StackoverflowContentLoader();
        var newContent = await soLoader.LoadAndParseContent(soUserId);
        File.WriteAllText(fileName, replacer.ReplaceContentBetween(startPhrase, endPhrase, newContent));

        Console.WriteLine(newContent);
    }
    else if(Directory.Exists(args[0])) {
        var dirInfo = new DirectoryInfo(args[0]);
        Console.WriteLine($"Directory: {dirInfo.FullName}");
    }
}
//https://api.stackexchange.com/docs