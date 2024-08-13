using System.Text.Json.Nodes;

namespace SwaggerDocGenerator.Readers.JsonUtilities;

public static class JsonPathUtility
{
    public static JsonNode? GetJsonObjectByPath(JsonNode input, string path)
    {
        if (path.StartsWith("#/") || path.StartsWith("$/") || path.StartsWith("?/"))
        {
            path = path.Substring(2);
        }
        var slashIndex = path.IndexOf('/');
        string currentPath = path;
        if (slashIndex > 0)
        {
            currentPath = path.Substring(0, slashIndex);
            path = path.Substring(slashIndex + 1);
        }
        else
        {
            path = "";
        }
        JsonNode? node = input.AsObject().FirstOrDefault(x => x.Key == currentPath).Value;
        if (node is null)
        {
            return null;
        }
        if (string.IsNullOrEmpty(path))
        {
            return node;
        }
        return GetJsonObjectByPath(node, path);
    }
}
