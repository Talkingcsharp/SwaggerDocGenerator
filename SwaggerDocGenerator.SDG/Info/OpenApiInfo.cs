using System.Text.Json.Serialization;

namespace SwaggerDocGenerator.SDG.Info;

public sealed class OpenApiInfo
{
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
