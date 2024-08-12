using System.Text.Json.Serialization;

namespace SwaggerDocGenerator.SDG.Routes.RouteResponses;

public sealed class OpenApiRouteResponseBody
{
    [JsonPropertyName("description")]
    public string Description { get; set; }

}
