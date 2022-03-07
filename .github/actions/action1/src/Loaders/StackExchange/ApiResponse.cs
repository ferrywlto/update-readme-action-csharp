using System.Text.Json.Serialization;

public record ApiResponse<T>(
    [property: JsonPropertyName("items")]
    T[] Items
);