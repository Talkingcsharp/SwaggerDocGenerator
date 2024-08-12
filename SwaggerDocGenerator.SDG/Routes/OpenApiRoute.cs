using SwaggerDocGenerator.SDG.Routes.RouteMethods;

namespace SwaggerDocGenerator.SDG.Routes;
public sealed class OpenApiRoute
{
    public Dictionary<string, OpenApiRouteMethod>? Methods { get; set; }
}
