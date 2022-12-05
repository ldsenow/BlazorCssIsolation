using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;

class Program
{
    public static async Task Main(string[] args)
    {
        var baseInputFolder = "../../../schemas";
        //var baseInputFolder = "../../../generated";
        var baseOutputFolder = "../../../../BlazorCssIsolation/Generated";

        //Delete existing files first
        Directory.GetFiles(baseOutputFolder, "*.cs").ToList().ForEach(File.Delete);

        var jsonFiles = Directory.GetFiles(baseInputFolder, "*.json");
        foreach (var f in jsonFiles)
        {
            var fileName = Path.GetFileNameWithoutExtension(f);
            await GenerateTokens(
                inputPath: f, 
                outputPath: Path.Combine(baseOutputFolder, $"{fileName}.cs"),
                outputTypeNamespace: $"BlazorCssIsolation.Tokens",
                fileName);
        }
    }

    private static async Task GenerateTokens(
        string inputPath, 
        string outputPath, 
        string outputTypeNamespace,
        string outputTypeName)
    {
        Console.WriteLine($"********Reading Json Schema from {inputPath}********");

        var schema = await NJsonSchema.JsonSchema.FromFileAsync(inputPath);
        var generator = new CSharpGenerator(schema, new CSharpGeneratorSettings
        {
            Namespace = outputTypeNamespace,
            SchemaType = NJsonSchema.SchemaType.JsonSchema,
            JsonLibrary = CSharpJsonLibrary.SystemTextJson,
            GenerateDataAnnotations = false,
            GenerateNativeRecords = true,
            GenerateOptionalPropertiesAsNullable = true,
            TypeNameGenerator = new StaticTypeNameGenerator(outputTypeName),
            ClassStyle = CSharpClassStyle.Record
        });
        var file = generator.GenerateFile();

        Console.WriteLine($"********Writting C# File to {outputPath}********");

        await File.WriteAllTextAsync(outputPath, file);
    }

    private class StaticTypeNameGenerator : DefaultTypeNameGenerator
    {
        public StaticTypeNameGenerator(string typeName)
        {
            TypeName = typeName;
        }

        public string TypeName { get; }

        protected override string Generate(JsonSchema schema, string typeNameHint)
        {
            return TypeName;
        }
    }
}