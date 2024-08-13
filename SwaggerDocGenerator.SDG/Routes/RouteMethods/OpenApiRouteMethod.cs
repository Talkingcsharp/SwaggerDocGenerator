using SwaggerDocGenerator.SDG.Routes.RouteParameters;
using SwaggerDocGenerator.SDG.Routes.RouteRequests;
using System.Text.Json.Serialization;

namespace SwaggerDocGenerator.SDG.Routes.RouteMethods;
public sealed class OpenApiRouteMethod
{
    public string[]? Tags { get; set; }
    public OpenApiRouteParameter[]? Parameters { get; set; }
    public OpenApiRequest? Request { get; set; }
}
