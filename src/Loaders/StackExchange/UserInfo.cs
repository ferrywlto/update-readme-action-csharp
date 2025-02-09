using System.Text.Json.Serialization;

namespace Loaders.StackExchange;
public record UserInfo(
    [property: JsonPropertyName("account_id")]
    int AccountId,
    [property: JsonPropertyName("user_id")]
    int UserId,
    [property: JsonPropertyName("reputation")]
    int Reputation,
    [property: JsonPropertyName("display_name")]
    string DisplayName
);