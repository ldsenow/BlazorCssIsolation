//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v10.8.0.0 (Newtonsoft.Json v9.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------


namespace BlazorCssIsolation.Tokens
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.8.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial record CommonMapToken
    {
        [System.Text.Json.Serialization.JsonConstructor]

        public CommonMapToken(double @borderRadiusLG, double @borderRadiusSM, double @borderRadiusXS, double @lineWidthBold, string @motionDurationFast, string @motionDurationMid, string @motionDurationSlow)


        {

            this.LineWidthBold = @lineWidthBold;

            this.BorderRadiusXS = @borderRadiusXS;

            this.BorderRadiusSM = @borderRadiusSM;

            this.BorderRadiusLG = @borderRadiusLG;

            this.MotionDurationFast = @motionDurationFast;

            this.MotionDurationMid = @motionDurationMid;

            this.MotionDurationSlow = @motionDurationSlow;

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


        [System.Text.Json.Serialization.JsonPropertyName("motionDurationFast")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
        public string MotionDurationFast { get; init; }


        [System.Text.Json.Serialization.JsonPropertyName("motionDurationMid")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
        public string MotionDurationMid { get; init; }


        [System.Text.Json.Serialization.JsonPropertyName("motionDurationSlow")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
        public string MotionDurationSlow { get; init; }


    }
}