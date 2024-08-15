using SwaggerDocGenerator.Readers;
using SwaggerDocGenerator.Readers.Abstractions;
using SwaggerDocGenerator.SDG;
using System.Text.Json;

string file = File.ReadAllText("swagger.json");
IOpenApiReader reader = new OpenApiJsonReader(file);
var output = reader.Parse();

Console.ReadLine();