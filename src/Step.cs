using Loaders;
namespace GitHub.Actions.UpdateReadme.CSharp;
public record Step(IContentLoader Loader, ContentReplacer Replacer, string Param);
