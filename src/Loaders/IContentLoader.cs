namespace Loaders;
public interface IContentLoader {
    Task<string> LoadAndParseContentAsync(string userId);
}
