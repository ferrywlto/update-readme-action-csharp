// See https://aka.ms/new-console-template for more information
Console.WriteLine($"args: {args.Length}");

if(args.Length > 0) {

    Console.WriteLine($"Hello, {(string.IsNullOrEmpty(args[0]) ? "Maid" : args[0])}!");

    if(File.Exists(args[0]))
    {
        var fileInfo = new FileInfo(args[0]);
        Console.WriteLine($"File: {fileInfo.FullName}");
    }
    else if(Directory.Exists(args[0])) {
        var dirInfo = new DirectoryInfo(args[0]);
        Console.WriteLine($"Directory: {dirInfo.FullName}");
    }
}




var time = DateTime.Now;
Console.WriteLine($"::set-output name=time::{time}");
