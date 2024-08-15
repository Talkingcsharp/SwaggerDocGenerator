using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SwaggerDocGenerator.SDG.Components;

public sealed class OpenApiComponentProperty
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }
    [JsonPropertyName("format")]
    public string? Format { get; set; }
    [JsonPropertyName("$ref")]

    public string? Refernece { get; set; }
    public OpenApiComponent? ReferneceComponent { get; set; }
    [JsonPropertyName("nullable")]
    public bool? IsNullable { get; set; }

    [JsonPropertyName("items")]
    public OpenApiComponentProperty? Items { get; set; }
}
