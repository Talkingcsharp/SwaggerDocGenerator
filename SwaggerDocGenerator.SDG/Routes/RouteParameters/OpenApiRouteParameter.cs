using System.Text.Json.Serialization;

namespace SwaggerDocGenerator.SDG.Routes.RouteParameters;

public sealed class OpenApiRouteParameter
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("in")]
    public string? InputParameterType { get; set; }
    [JsonPropertyName("schema")]
    public OpenApiRouteParameterSchema? Schema { get; set; }
}
