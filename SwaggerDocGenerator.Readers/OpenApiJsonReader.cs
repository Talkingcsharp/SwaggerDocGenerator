using SwaggerDocGenerator.Readers.Abstractions;
using SwaggerDocGenerator.SDG;
using SwaggerDocGenerator.SDG.Info;
using SwaggerDocGenerator.SDG.Routes;
using SwaggerDocGenerator.SDG.Routes.RouteMethods;
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
        input.Routes = new Dictionary<string, OpenApiRoute>();
        JsonObject? pathsRoot = mainObject.FirstOrDefault(w => w.Key == Abstractions.JsonPropertyNames.OpenApiDef.Routes).Value?.AsObject();
        if (pathsRoot is null)
        {
            return;
        }
        var enumerator = pathsRoot.GetEnumerator();
        while (enumerator.MoveNext())
        {
            input.Routes.Add(enumerator.Current.Key.ToString(), ReadRoute(enumerator.Current.Value?.AsObject(), mainObject));
        }
    }
    private OpenApiRoute ReadRoute(JsonObject? input, JsonObject mainObject)
    {
        var output = new OpenApiRoute();
        output.Methods = new Dictionary<string, SDG.Routes.RouteMethods.OpenApiRouteMethod>();
        var enumerator = input.GetEnumerator();
        while (enumerator.MoveNext())
        {
            output.Methods.Add(enumerator.Current.Key.ToString(), ReadMethod(enumerator.Current.Value?.AsObject(), mainObject));
        }
        return output;
    }
    private OpenApiRouteMethod ReadMethod(JsonObject? input, JsonObject mainObject)
    {
        return new OpenApiRouteMethod();
    }
}
