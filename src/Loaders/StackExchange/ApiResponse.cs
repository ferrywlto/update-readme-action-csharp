using System.Text.Json.Serialization;

namespace Loaders.StackExchange;
public record ApiResponse<T>(
    [property: JsonPropertyName("items")]
    T[] Items
);