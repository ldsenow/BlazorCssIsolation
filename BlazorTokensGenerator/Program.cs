using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;

class Program
{
    public static async Task Main(string[] args)
    {
        var baseInputFolder = "./generated/schemas";
        var baseOutputFolder = "../../../../BlazorCssIsolation.Theming/Generated";
        var classNamespace = "BlazorCssIsolation.Theming.Tokens";

        await GenerateTokenClasses(classNamespace, baseInputFolder, baseOutputFolder);
    }

    private static async Task GenerateTokenClasses(string classNamespace, string inputFolder, string outputFolder)
    {
        //Delete existing files first
        Directory.GetFiles(outputFolder, "*.cs").ToList().ForEach(File.Delete);

        var jsonFiles = Directory.GetFiles(inputFolder, "*.json");
        foreach (var f in jsonFiles)
        {
            var fileName = Path.GetFileNameWithoutExtension(f);
            await WriteTokenClass(
                inputPath: f,
                outputPath: Path.Combine(outputFolder, $"{fileName}.cs"),
                outputTypeNamespace: classNamespace,
                fileName);
        }
    }

    private static async Task WriteTokenClass(
        string inputPath,
        string outputPath,
        string outputTypeNamespace,
        string outputTypeName)
    {
        Console.WriteLine($"********Reading Json Schema from {inputPath}********");

        var schema = await JsonSchema.FromFileAsync(inputPath);
        var generator = new CSharpGenerator(schema, new CSharpGeneratorSettings
        {
            Namespace = outputTypeNamespace,
            SchemaType = SchemaType.JsonSchema,
            JsonLibrary = CSharpJsonLibrary.SystemTextJson,
            GenerateDataAnnotations = false,
            GenerateNativeRecords = true,
            GenerateOptionalPropertiesAsNullable = true,
            GenerateNullableReferenceTypes = true,
            GenerateJsonMethods = true,
            TypeNameGenerator = new StaticTypeNameGenerator(outputTypeName),
            ClassStyle = CSharpClassStyle.Record,
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