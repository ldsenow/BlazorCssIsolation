//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v10.8.0.0 (Newtonsoft.Json v9.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------


#nullable enable


namespace BlazorCssIsolation.Tokens
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.8.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial record SizeMapToken
    {
        [System.Text.Json.Serialization.JsonConstructor]

        public SizeMapToken(double @size, double @sizeLG, double @sizeMD, double @sizeMS, double @sizeSM, double @sizeXL, double @sizeXS, double @sizeXXL, double @sizeXXS)


        {

            this.SizeXXL = @sizeXXL;

            this.SizeXL = @sizeXL;

            this.SizeLG = @sizeLG;

            this.SizeMD = @sizeMD;

            this.SizeMS = @sizeMS;

            this.Size = @size;

            this.SizeSM = @sizeSM;

            this.SizeXS = @sizeXS;

            this.SizeXXS = @sizeXXS;

        }
        [System.Text.Json.Serialization.JsonPropertyName("sizeXXL")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
        public double SizeXXL { get; init; }


        [System.Text.Json.Serialization.JsonPropertyName("sizeXL")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
        public double SizeXL { get; init; }


        [System.Text.Json.Serialization.JsonPropertyName("sizeLG")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
        public double SizeLG { get; init; }


        [System.Text.Json.Serialization.JsonPropertyName("sizeMD")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
        public double SizeMD { get; init; }

        /// <summary>
        /// Same as size by default, but could be larger in compact mode
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("sizeMS")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
        public double SizeMS { get; init; }


        [System.Text.Json.Serialization.JsonPropertyName("size")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
        public double Size { get; init; }


        [System.Text.Json.Serialization.JsonPropertyName("sizeSM")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
        public double SizeSM { get; init; }


        [System.Text.Json.Serialization.JsonPropertyName("sizeXS")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
        public double SizeXS { get; init; }


        [System.Text.Json.Serialization.JsonPropertyName("sizeXXS")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.Never)]   
        public double SizeXXS { get; init; }


    }
}