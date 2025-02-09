using System.Text.Json.Serialization;

namespace Loaders.StackExchange;
public record UserActivity(
    [property: JsonPropertyName("creation_date")]
    int CreationDate,
    [property: JsonPropertyName("activity_type")]
    string ActivityType,
    [property: JsonPropertyName("link")]
    string Link,
    [property: JsonPropertyName("title")]
    string Title
);
