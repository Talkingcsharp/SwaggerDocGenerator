using SwaggerDocGenerator.SDG.Components;
using System.Text.Json.Serialization;

namespace SwaggerDocGenerator.SDG.Routes.RouteResponses;

public sealed class OpenApiRouteResponseBody
{
    public string? Description { get; set; }
    public string? Summary { get; set; }

    public Dictionary<string, OpenApiComponent>? Content { get; set; }
}