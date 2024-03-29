//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v10.8.0.0 (Newtonsoft.Json v9.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------


#nullable enable


namespace BlazorCssIsolation.Theming.Tokens
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.8.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial record StyleMapToken
    {
        [System.Text.Json.Serialization.JsonConstructor]

        public StyleMapToken(double @borderRadiusLG, double @borderRadiusOuter, double @borderRadiusSM, double @borderRadiusXS, double @lineWidthBold)


        {

            this.LineWidthBold = @lineWidthBold;

            this.BorderRadiusXS = @borderRadiusXS;

            this.BorderRadiusSM = @borderRadiusSM;

            this.BorderRadiusLG = @borderRadiusLG;

            this.BorderRadiusOuter = @borderRadiusOuter;

        }
        [System.Text.Json.Serialization.JsonPropertyName("lineWidthBold")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
        public double LineWidthBold { get; init; }


        [System.Text.Json.Serialization.JsonPropertyName("borderRadiusXS")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
        public double BorderRadiusXS { get; init; }


        [System.Text.Json.Serialization.JsonPropertyName("borderRadiusSM")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
        public double BorderRadiusSM { get; init; }


        [System.Text.Json.Serialization.JsonPropertyName("borderRadiusLG")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
        public double BorderRadiusLG { get; init; }


        [System.Text.Json.Serialization.JsonPropertyName("borderRadiusOuter")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
        public double BorderRadiusOuter { get; init; }


        public string ToJson()
        {

            var options = new System.Text.Json.JsonSerializerOptions();

            return System.Text.Json.JsonSerializer.Serialize(this, options);

        }
        public static StyleMapToken FromJson(string data)
        {

            var options = new System.Text.Json.JsonSerializerOptions();

            return System.Text.Json.JsonSerializer.Deserialize<StyleMapToken>(data, options);

        }

    }
}