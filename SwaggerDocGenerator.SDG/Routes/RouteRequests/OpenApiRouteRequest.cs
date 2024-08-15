using SwaggerDocGenerator.SDG.Components;

namespace SwaggerDocGenerator.SDG.Routes.RouteRequests;
public sealed class OpenApiRouteRequest
{
    public Dictionary<string, OpenApiComponent>? Content { get; set; }
}