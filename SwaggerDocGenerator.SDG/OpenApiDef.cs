using SwaggerDocGenerator.SDG.Info;
using SwaggerDocGenerator.SDG.Routes;
using System.Text.Json.Serialization;

namespace SwaggerDocGenerator.SDG;
public sealed class OpenApiDef
{
    public string? OpenAPI { get; set; }
    public OpenApiInfo? Info { get; set; }
    public Dictionary<string, OpenApiRoute>? Routes { get; set; }
}
