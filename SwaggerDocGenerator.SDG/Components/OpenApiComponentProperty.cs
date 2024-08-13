using System.Text.Json.Serialization;

namespace SwaggerDocGenerator.SDG.Components;

public sealed class OpenApiComponentProperty
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }
    [JsonPropertyName("format")]
    public string? Format { get; set; }
}
