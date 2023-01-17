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
    public partial record HeightMapToken
    {
        [System.Text.Json.Serialization.JsonConstructor]

        public HeightMapToken(double @controlHeightLG, double @controlHeightSM, double @controlHeightXS)


        {

            this.ControlHeightXS = @controlHeightXS;

            this.ControlHeightSM = @controlHeightSM;

            this.ControlHeightLG = @controlHeightLG;

        }
        [System.Text.Json.Serialization.JsonPropertyName("controlHeightXS")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
        public double ControlHeightXS { get; init; }


        [System.Text.Json.Serialization.JsonPropertyName("controlHeightSM")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
        public double ControlHeightSM { get; init; }


        [System.Text.Json.Serialization.JsonPropertyName("controlHeightLG")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
        public double ControlHeightLG { get; init; }


    }
}