using SwaggerDocGenerator.SDG;

namespace SwaggerDocGenerator.Readers.Abstractions;
public interface IOpenApiReader
{
    OpenApiDef Parse();
}
