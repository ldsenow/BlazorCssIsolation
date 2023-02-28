namespace BlazorCssIsolation.Theming.Tokens;

public partial record SeedToken : TokenBase
{
    //TODO: find a way to extract these default seed from TS if possible
    //e.g. export from seed.ts as json with the values
    public static readonly SeedToken Default = new(
        blue: "#1677ff",
        purple: "#722ed1",
        cyan: "#13c2c2",
        green: "#52c41a",
        magenta: "#eb2f96",
        pink: "#eb2f96",
        red: "#f5222d",
        orange: "#fa8c16",
        yellow: "#fadb14",
        volcano: "#fa541c",
        geekblue: "#2f54eb",
        gold: "#faad14",
        lime: "#a0d911",

        // Color
        colorPrimary: "#1677ff",
        colorSuccess: "#52c41a",
        colorWarning: "#faad14",
        colorError: "#ff4d4f",
        colorInfo: "#1677ff",
        colorTextBase: "#000",
        colorBgBase: "#fff",

        // Font
        fontFamily: "-apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, 'Helvetica Neue', Arial, 'Noto Sans', sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol', 'Noto Color Emoji'",
        fontFamilyCode: "'SFMono-Regular', Consolas, 'Liberation Mono', Menlo, Courier, monospace",
        fontSize: 14,

        // Line
        lineWidth: 1,
        lineType: "solid",

        // Motion
        motionUnit: 0.1,
        motionBase: 0,
        motionEaseOutCirc: "cubic-bezier(0.08, 0.82, 0.17, 1)",
        motionEaseInOutCirc: "cubic-bezier(0.78, 0.14, 0.15, 0.86)",
        motionEaseOut: "cubic-bezier(0.215, 0.61, 0.355, 1)",
        motionEaseInOut: "cubic-bezier(0.645, 0.045, 0.355, 1)",
        motionEaseOutBack: "cubic-bezier(0.12, 0.4, 0.29, 1.46)",
        motionEaseInBack: "cubic-bezier(0.71, -0.46, 0.88, 0.6)",
        motionEaseInQuint: "cubic-bezier(0.755, 0.05, 0.855, 0.06)",
        motionEaseOutQuint: "cubic-bezier(0.23, 1, 0.32, 1)",

        // Radius
        borderRadius: 6,

        // Size
        sizeUnit: 4,
        sizeStep: 4,
        sizePopupArrow: 16,

        // Control Base
        controlHeight: 32,

        // zIndex
        zIndexBase: 0,
        zIndexPopupBase: 1000,

        // Image
        opacityImage: 1,

        // Wireframe
        wireframe: false);
}
