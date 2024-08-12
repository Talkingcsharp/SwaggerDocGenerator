using SwaggerDocGenerator.Readers.Abstractions;
using SwaggerDocGenerator.SDG;
using SwaggerDocGenerator.SDG.Info;
using SwaggerDocGenerator.SDG.Routes;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SwaggerDocGenerator.Readers;
public class OpenApiJsonReader : IOpenApiReader
{
    private readonly string _json;

    public OpenApiJsonReader(string jsonString)
    {
        _json = jsonString;
    }

    public OpenApiDef Parse()
    {
        JsonObject? mainObject = JsonObject.Parse(_json)?.AsObject();
        ArgumentNullException.ThrowIfNull(mainObject);
        var output = new OpenApiDef();
        output.OpenAPI = mainObject.FirstOrDefault(x => x.Key == Abstractions.JsonPropertyNames.OpenApiDef.OpenApi).Value?.ToString();
        output.Info = mainObject.FirstOrDefault(x => x.Key == Abstractions.JsonPropertyNames.OpenApiDef.Info).Value?.Deserialize<OpenApiInfo>();
        ReadRoutes(mainObject, output);
        return output;
    }

    private void ReadRoutes(JsonObject mainObject, OpenApiDef input)
    {

    }
    private OpenApiRoute ReadRoute(JsonObject input)
    {

    }
}
