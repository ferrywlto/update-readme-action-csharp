using System.Text;

Console.WriteLine($"args: {args.Length}");
if(args.Length <= 0) throw new ArgumentException("Please supply arguments.");

var filePath = args[0];
if(!File.Exists(filePath)) throw new FileNotFoundException($"Cannot find file {filePath} to edit.");

var text = File.ReadAllText(filePath);
var replacer = new ContentReplacer(text);
// var sb = new StringBuilder(text);

int soUserId;
if (args.Length > 1) {
    if(args[1].Equals("unknown"))
        throw new ArgumentException("Please supply arguemnt: `stackoverflow-user-id` to action.");

    soUserId = int.Parse(args[1]);
    var soLoader = new StackoverflowContentLoader();
    var newContent = await soLoader.LoadAndParseContent(soUserId);

    var startPhrase = "<!-- STACKOVERFLOW:START -->";
    var endPhrase = "<!-- STACKOVERFLOW:END -->";
    text = replacer.ReplaceContentBetween(startPhrase, endPhrase, newContent);
}

File.WriteAllText(filePath, text);


//https://api.stackexchange.com/docs
//https://github.com/Medium/medium-api-docs
