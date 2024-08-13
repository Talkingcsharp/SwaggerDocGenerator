using System.Text.Json.Serialization;

namespace SwaggerDocGenerator.SDG.Routes.RouteRequests;
public sealed class OpenApiRouteRequestBody
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }
    [JsonPropertyName("properties")]
    public Dictionary<string, OpenApiRequestBodyProperty>? Properties { get; set; }
}
