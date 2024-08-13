using SwaggerDocGenerator.SDG.Components;

namespace SwaggerDocGenerator.SDG.Routes.RouteRequests;
public sealed class OpenApiRequest
{
    public Dictionary<string, OpenApiComponent>? Content { get; set; }
}