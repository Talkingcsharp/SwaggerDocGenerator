using System.Text.Json.Serialization;

namespace SwaggerDocGenerator.SDG.Routes.RouteRequests;

public sealed class OpenApiRequestBodyProperty
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }
    [JsonPropertyName("format")]
    public string? Format { get; set; }
}
