using System.Text;

Console.WriteLine($"args: {args.Length}");
if(args.Length <= 0) throw new ArgumentException("Please supply arguments.");

var filePath = args[0];
if(!File.Exists(filePath)) throw new FileNotFoundException($"Cannot find file {filePath} to edit.");

var text = File.ReadAllText(filePath);
var replacer = new ContentReplacer(text);
// var sb = new StringBuilder(text);

if (args.Length > 1) {
    if(args[1].Equals("unknown"))
        throw new ArgumentException("Please supply arguemnt: `medium-user-id` to action.");

    var soLoader = new MediumContentLoader();
    var newContent = await soLoader.LoadAndParseContentAsync(args[1]);

    var startPhrase = "<!-- MEDIUM:START -->";
    var endPhrase = "<!-- MEDIUM:END -->";
    text = replacer.ReplaceContentBetween(startPhrase, endPhrase, newContent);
}

if (args.Length > 2) {
    if(args[2].Equals("unknown"))
        throw new ArgumentException("Please supply arguemnt: `stackoverflow-user-id` to action.");

    var soLoader = new StackoverflowContentLoader();
    var newContent = await soLoader.LoadAndParseContentAsync(args[2]);

    var startPhrase = "<!-- STACKOVERFLOW:START -->";
    var endPhrase = "<!-- STACKOVERFLOW:END -->";
    text = replacer.ReplaceContentBetween(startPhrase, endPhrase, newContent);
}

File.WriteAllText(filePath, text);


//https://api.stackexchange.com/docs
//https://github.com/Medium/medium-api-docs
//293b75ad72ca711572570de4ae4c66d7d4f1b5408eb4e1ab2b698e50c488a813d