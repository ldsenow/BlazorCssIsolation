namespace BlazorCssIsolation.Tokens;

public partial record SeedToken : TokenBase
{
    //TODO: find a way to extract these default seed from TS if possible
    //e.g. export from seed.ts as json with the values
    public static readonly SeedToken Default = new(
        blue: "#1677ff",
        borderRadius: 6,
        colorBgBase: "",
        colorError: "#f5222d",
        colorInfo: "#1677ff",
        colorPrimary: "#1677ff",
        colorSuccess: "#52c41a",
        colorTextBase: "",
        colorWarning: "#faad14",
        controlHeight: 32,
        cyan: "#13c2c2",
        fontFamily: "-apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, 'Helvetica Neue', Arial, 'Noto Sans', sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol', 'Noto Color Emoji'",
        fontSize: 14,
        geekblue: "#2f54eb",
        gold: "#faad14",
        green: "#52c41a",
        lime: "#a0d911",
        lineType: "solid",
        lineWidth: 1,
        magenta: "#eb2F96",
        motionUnit: 0.1,
        orange: "#fa8c16",
        pink: "#eb2f96",
        purple: "#722ed1",
        red: "#f5222d",
        sizeStep: 4,
        sizeUnit: 4,
        volcano: "#fa541c",
        wireframe: false,
        yellow: "#fadb14",
        zIndexBase: 0,
        zIndexPopupBase: 1000);
}
