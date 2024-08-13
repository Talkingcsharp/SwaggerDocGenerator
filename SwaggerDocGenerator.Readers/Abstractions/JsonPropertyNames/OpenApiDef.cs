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
            internal static class OpenApiRequest
            {
                public const string Content = "content";
            }
        }
    }
}