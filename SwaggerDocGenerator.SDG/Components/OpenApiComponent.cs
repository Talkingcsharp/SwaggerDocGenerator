using SwaggerDocGenerator.SDG.Routes.RouteRequests;
using System.Text.Json.Serialization;

namespace SwaggerDocGenerator.SDG.Components;
public sealed class OpenApiComponent
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }
    [JsonPropertyName("properties")]
    public Dictionary<string, OpenApiComponentProperty>? Properties { get; set; }
    [JsonPropertyName("additionalProperties")]
    public bool? HasAdditionalProperties { get; set; }
}
