namespace BlazorCssIsolation.Theming.Themes;

public interface IColorDerivative
{
    IColor[] Derive(IColor primary, ColorDerivativeOptions? options = default);
}

//https://github.com/ant-design/ant-design-colors
public class ColorDerivative : IColorDerivative
{
    //TODO: Consider to move these settings into ThemeGenerationOptions
    private const int hueStep = 2; // 色相阶梯
    private const double saturationStep = 0.16; // 饱和度阶梯，浅色部分
    private const double saturationStep2 = 0.05; // 饱和度阶梯，深色部分
    private const double brightnessStep1 = 0.05; // 亮度阶梯，浅色部分
    private const double brightnessStep2 = 0.15; // 亮度阶梯，深色部分
    private const int lightColorCount = 5; // 浅色数量，主色上
    private const int darkColorCount = 4; // 深色数量，主色下

    // 暗色主题颜色映射关系表
    private static readonly List<(int Index, double Opacity)> darkColorMap = new()
    {
        (Index: 7, Opacity: 0.15),
        (Index: 6, Opacity: 0.25),
        (Index: 5, Opacity: 0.30),
        (Index: 5, Opacity: 0.45),
        (Index: 5, Opacity: 0.65),
        (Index: 5, Opacity: 0.85),
        (Index: 4, Opacity: 0.90),
        (Index: 3, Opacity: 0.95),
        (Index: 2, Opacity: 0.97),
        (Index: 1, Opacity: 0.98),
    };

    public IColor[] Derive(IColor primary, ColorDerivativeOptions? options = default)
    {
        List<HEX> patterns = new();

        var hsv = primary.ToHSV();

        for (var i = lightColorCount; i > 0; i -= 1)
        {
            var mixedHsv = new HSV(
                MixHue(hsv, i, true),
                MixSaturation(hsv, i, true),
                MixValue(hsv, i, true));

            patterns.Add(mixedHsv.ToHEX());
        }

        patterns.Add(primary.ToHEX());

        for (var i = 1; i <= darkColorCount; i += 1)
        {
            var mixedHsv = new HSV(
                MixHue(hsv, i, false),
                MixSaturation(hsv, i, false),
                MixValue(hsv, i, false));

            patterns.Add(mixedHsv.ToHEX());
        }

        if (options?.Dark == true)
        {
            var bgRgb = (options.BackgroundColor ?? new HEX("#141414")).ToRGB();

            return darkColorMap
                .Select(x => MixRGB(bgRgb, patterns[x.Index].ToRGB(), x.Opacity * 100.0).ToHEX())
                .ToArray();
        }
        else
        {
            return patterns.ToArray();
        }
    }

    private static double MixHue(HSV color, int amount, bool light)
    {
        double hue;
        double h = Math.Round(color.H, MidpointRounding.AwayFromZero);

        // 根据色相不同，色相转向不同
        if (h>= 60 && h<= 240)
        {
            hue = light ? h - hueStep * amount : h + hueStep * amount;
        }
        else
        {
            hue = light ? h + hueStep * amount : h - hueStep * amount;
        }

        if (hue < 0)
        {
            hue += 360;
        }
        else if (hue >= 360)
        {
            hue -= 360;
        }

        return hue;
    }

    private static double MixSaturation(HSV color, int amount, bool light)
    {
        // grey color don't change saturation
        if (color.H == 0 && color.S == 0)
        {
            return color.S;
        }

        double saturation;
        if (light)
        {
            saturation = color.S - saturationStep * amount;
        }
        else if (amount == darkColorCount)
        {
            saturation = color.S + saturationStep;
        }
        else
        {
            saturation = color.S + saturationStep2 * amount;
        }

        // Restrict the first light saturation <= 0.1
        if (light && amount == lightColorCount && saturation > 0.1)
        {
            saturation = 0.1;
        }

        saturation = Math.Clamp(saturation, 0.06, 1);

        return Math.Round(saturation, 2, MidpointRounding.AwayFromZero);
    }

    private static double MixValue(HSV color, int amount, bool light)
    {
        double value = light
            ? color.V + brightnessStep1 * amount
            : color.V - brightnessStep2 * amount;

        return Math.Round(Math.Min(value, 1), 2, MidpointRounding.AwayFromZero);
    }

    // Wrapper function ported from TinyColor.prototype.mix, not treeshakable.
    // Amount in range [0, 1]
    // Assume color1 & color2 has no alpha, since the following src code did so.
    private static RGB MixRGB(RGB rgb1, RGB rgb2, double amount)
    {
        if (amount > 100 || amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount));

        var p = amount / 100.0;

        var mix = (double v1, double v2) => (v2 - v1) * p + v1;

        var r = mix(rgb1.R, rgb2.R);
        var g = mix(rgb1.G, rgb2.G);
        var b = mix(rgb1.B, rgb2.B);

        return new RGB(r, g, b);
    }
}

public record ColorDerivativeOptions
{
    public bool Dark { get; set; }
    public HEX? BackgroundColor { get; set; }
}