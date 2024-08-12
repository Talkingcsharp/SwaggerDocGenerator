using System.Text.Json.Serialization;

namespace SwaggerDocGenerator.SDG.Routes.RouteParameters;

public sealed class OpenApiRouteParameterSchema
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }
    [JsonPropertyName("format")]
    public string? TypeFormat { get; set; }
}
