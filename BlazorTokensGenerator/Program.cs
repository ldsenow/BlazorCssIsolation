using NJsonSchema.CodeGeneration.CSharp;

var schemaJsonFilePath = Path.GetFullPath("../../../schema.json");

Console.WriteLine($"********Reading Json Schema from {schemaJsonFilePath}********");

var schema = await NJsonSchema.JsonSchema.FromFileAsync(schemaJsonFilePath);
var generator = new CSharpGenerator(schema, new CSharpGeneratorSettings
{
    SchemaType = NJsonSchema.SchemaType.JsonSchema,
    Namespace = "BlazorCssIsolation",
    GenerateDataAnnotations = false,
    GenerateNativeRecords = true,
    JsonLibrary = CSharpJsonLibrary.SystemTextJson,
    GenerateOptionalPropertiesAsNullable = true,
});
var file = generator.GenerateFile();

var outputFilePath = Path.GetFullPath("../../../../BlazorCssIsolation/AntTokens.cs");

Console.WriteLine($"********Writting C# File to {outputFilePath}********");

await File.WriteAllTextAsync(outputFilePath, file);