using SwaggerDocGenerator.SDG.Routes.RouteParameters;
using System.Text.Json.Serialization;

namespace SwaggerDocGenerator.SDG.Routes.RouteMethods;
public sealed class OpenApiRouteMethod
{
    [JsonPropertyName("tags")]
    public string[]? Tags { get; set; }
    [JsonPropertyName("parameters")]
    public OpenApiRouteParameter[]? Parameters { get; set; }
}
