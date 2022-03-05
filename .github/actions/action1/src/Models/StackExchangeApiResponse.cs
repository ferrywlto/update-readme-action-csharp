using System.Text.Json.Serialization;

public record StackExchangeApiResponse<T>(
    [property: JsonPropertyName("items")]
    T[] Items
);