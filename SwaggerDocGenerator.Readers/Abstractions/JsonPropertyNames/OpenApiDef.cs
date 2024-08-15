using System.Runtime.CompilerServices;

namespace SwaggerDocGenerator.Readers.Abstractions.JsonPropertyNames;

public static class OpenApiDef
{
    public const string OpenApi = "openapi";
    public const string Info = "info";
    public const string Routes = "paths";
    internal static class OpenApiRoute
    {
        internal static class OpenApiRouteMethod
        {
            public const string Tags = "tags";
            public const string Parameters = "parameters";
            public const string Request = "requestBody";
            public const string Responses = "responses";
            internal static class OpenApiRouteRequest
            {
                public const string Content = "content";
                public const string Schema = "schema";
                public const string Refernece = "$ref";
            }
            internal static class OpenApiRouteResponse
            {
                internal static class OpenApiRouteResponseBody
                {
                    public const string Description = "description";
                    public const string Content = "content";
                    public const string Summary = "summary";
                }
            }
        }
    }
}