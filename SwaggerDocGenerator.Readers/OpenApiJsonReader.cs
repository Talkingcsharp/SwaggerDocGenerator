using SwaggerDocGenerator.Readers.Abstractions;
using SwaggerDocGenerator.Readers.JsonUtilities;
using SwaggerDocGenerator.SDG;
using SwaggerDocGenerator.SDG.Components;
using SwaggerDocGenerator.SDG.Info;
using SwaggerDocGenerator.SDG.Routes;
using SwaggerDocGenerator.SDG.Routes.RouteMethods;
using SwaggerDocGenerator.SDG.Routes.RouteParameters;
using SwaggerDocGenerator.SDG.Routes.RouteRequests;
using SwaggerDocGenerator.SDG.Routes.RouteResponses;
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
        OpenApiRouteMethod output = new OpenApiRouteMethod();
        if (input is null)
        {
            return output;
        }
        output.Tags = input.FirstOrDefault(x => x.Key == Abstractions.JsonPropertyNames.OpenApiDef.OpenApiRoute.OpenApiRouteMethod.Tags).Value?.AsArray().Select(x => x.ToString()).ToArray();
        var paramJsonList = input.FirstOrDefault(x => x.Key == Abstractions.JsonPropertyNames.OpenApiDef.OpenApiRoute.OpenApiRouteMethod.Parameters).Value?.AsArray();
        if (paramJsonList is not null)
        {
            List<OpenApiRouteParameter?> paramList = new List<OpenApiRouteParameter?>();
            foreach (var item in paramJsonList)
            {
                paramList.Add(item.Deserialize<OpenApiRouteParameter>());
            }
            output.Parameters = paramList.ToArray();
        }

        var requestJson = input.FirstOrDefault(x => x.Key == Abstractions.JsonPropertyNames.OpenApiDef.OpenApiRoute.OpenApiRouteMethod.Request).Value?.AsObject();
        output.Request = ReadRequest(requestJson, mainObject);

        var responsesJson = input.FirstOrDefault(x => x.Key == Abstractions.JsonPropertyNames.OpenApiDef.OpenApiRoute.OpenApiRouteMethod.Responses).Value?.AsObject();
        if (responsesJson is null)
        {
            return output;
        }
        output.Response = ReadResponses(responsesJson, mainObject);
        return output;

    }
    private OpenApiRouteRequest? ReadRequest(JsonObject? input, JsonObject mainObject)
    {
        OpenApiRouteRequest output = new OpenApiRouteRequest();
        if (input is null)
        {
            return null;
        }
        var contentJeon = input.FirstOrDefault(w => w.Key == Abstractions.JsonPropertyNames.OpenApiDef.OpenApiRoute.OpenApiRouteMethod.OpenApiRouteRequest.Content).Value?.AsObject();
        if (contentJeon is null)
        {
            return null;
        }
        output.Content = new Dictionary<string, SDG.Components.OpenApiComponent>();
        var enumerator = contentJeon.GetEnumerator();
        while (enumerator.MoveNext())
        {
            string? schemaRefJson = enumerator.Current.Value?.AsObject().FirstOrDefault(w => w.Key == Abstractions.JsonPropertyNames.OpenApiDef.OpenApiRoute.OpenApiRouteMethod.OpenApiRouteRequest.Schema).Value?
                .AsObject().FirstOrDefault(x => x.Key == Abstractions.JsonPropertyNames.OpenApiDef.OpenApiRoute.OpenApiRouteMethod.OpenApiRouteRequest.Refernece).Value?.ToString();

            if (schemaRefJson is null)
            {
                continue;
            }
            var requestBody = ReadComponent(schemaRefJson, mainObject);
            if (requestBody is null)
            {
                continue;
            }
            output.Content.Add(enumerator.Current.Key, requestBody);
        }
        if (output.Content.Count == 0)
        {
            return null;
        }
        return output;
    }
    private OpenApiRouteResponse? ReadResponses(JsonObject? input, JsonObject mainObject)
    {
        if (input is null)
        {
            return null;
        }

        var enumerator = input.GetEnumerator();
        if (enumerator is null)
        {
            return null;
        }
        OpenApiRouteResponse response = new();
        response.ResponseCodes = new();
        while (enumerator.MoveNext())
        {
            var responseBody = new OpenApiRouteResponseBody();
            response.ResponseCodes.Add(enumerator.Current.Key, responseBody);
            responseBody.Summary = enumerator.Current.Value?.AsObject().FirstOrDefault(s => s.Key == Abstractions.JsonPropertyNames.OpenApiDef.OpenApiRoute.OpenApiRouteMethod.OpenApiRouteResponse.OpenApiRouteResponseBody.Summary).Value?.ToString();
            responseBody.Description = enumerator.Current.Value?.AsObject().FirstOrDefault(s => s.Key == Abstractions.JsonPropertyNames.OpenApiDef.OpenApiRoute.OpenApiRouteMethod.OpenApiRouteResponse.OpenApiRouteResponseBody.Description).Value?.ToString();
            var jsonContents = enumerator.Current.Value?.AsObject().FirstOrDefault(s => s.Key == Abstractions.JsonPropertyNames.OpenApiDef.OpenApiRoute.OpenApiRouteMethod.OpenApiRouteResponse.OpenApiRouteResponseBody.Content).Value?.AsObject();
            responseBody.Content = ReadResponseBodies(jsonContents, mainObject);
        }
    }
    private Dictionary<string, OpenApiComponent>? ReadResponseBodies(JsonObject? input, JsonObject mainObject)
    {
        if (input is null)
        {
            return null;
        }
        var enumerator = input.GetEnumerator();
        if (enumerator is null)
        {
            return null;
        }
        var output = new Dictionary<string, OpenApiComponent>();
        while (enumerator.MoveNext())
        {
        }
    }

    private OpenApiComponent? ReadComponent(string path, JsonObject mainObject)
    {
        JsonObject? node = JsonPathUtility.GetJsonObjectByPath(mainObject, path)?.AsObject();
        if (node is null)
        {
            return null;
        }
        var component = node.Deserialize<OpenApiComponent>();
        if (component is null)
        {
            return null;
        }
        if (component.Properties is null)
        {
            return component;
        }

        foreach (var property in component.Properties)
        {
            if (property.Value?.Refernece is not null)
            {
                node = JsonPathUtility.GetJsonObjectByPath(mainObject, property.Value.Refernece)?.AsObject();
                if (node is null)
                {
                    continue;
                }
                property.Value.ReferneceComponent = node.Deserialize<OpenApiComponent>();
            }
            if (property.Value?.Items?.Refernece is not null)
            {
                node = JsonPathUtility.GetJsonObjectByPath(mainObject, property.Value?.Items?.Refernece)?.AsObject();
                if (node is null)
                {
                    continue;
                }
                property.Value.Items.ReferneceComponent = node.Deserialize<OpenApiComponent>();
            }
        }

        return component;
    }


}
