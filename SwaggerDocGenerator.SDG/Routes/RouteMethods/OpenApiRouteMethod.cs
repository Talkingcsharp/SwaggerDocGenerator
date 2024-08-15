using SwaggerDocGenerator.SDG.Routes.RouteParameters;
using SwaggerDocGenerator.SDG.Routes.RouteRequests;
using SwaggerDocGenerator.SDG.Routes.RouteResponses;
using System.Text.Json.Serialization;

namespace SwaggerDocGenerator.SDG.Routes.RouteMethods;
public sealed class OpenApiRouteMethod
{
    public string[]? Tags { get; set; }
    public OpenApiRouteParameter?[]? Parameters { get; set; }
    public OpenApiRouteRequest? Request { get; set; }
    public OpenApiRouteResponse? Response { get; set; }
}
