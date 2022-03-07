Console.WriteLine($"args: {args.Length}");
if (args.Length <= 0) throw new ArgumentException("Please supply arguments.");

var filePath = args[0];

if (!File.Exists(filePath)) throw new FileNotFoundException($"Cannot find file {filePath} to edit.");

string[] sequence = new[] {"","MEDIUM", "STACKOVERFLOW"};
var action = new ReplaceReadmeContentAction();

const string paramValueDefault = "unknown";
const string argumentErrorStr = "Please supply arguemnt: `{0}` to action.";
const string paramNameDefault = "{0}-user-id";

for(var i=1; i<args.Length; i+=1) {
    var param = args[i];
    if (string.IsNullOrEmpty(param) || param.Equals(paramValueDefault))
        throw new ArgumentException(string.Format(argumentErrorStr, string.Format(paramNameDefault, sequence[i].ToLower())));

    action.AddStep(new Step(
        ContentLoaderFactory.GetContentLoader(sequence[i]),
        new ContentReplacer(sequence[i]),
        args[i]
    ));
}

var text = File.ReadAllText(filePath);
text = await action.Run(text);
File.WriteAllText(filePath, text);