using static BlazorCssIsolation.Themes.ThemeGenerator;

namespace BlazorCssIsolation.Themes
{
    public interface IThemeGenerator
    {
        HEX[] Generate(HEX seed, ThemeGenerationOptions? options = default);
    }

    public class ThemeGenerator : IThemeGenerator
    {
        private const int hueStep = 2; // 色相阶梯
        private const int saturationStep = 16; // 饱和度阶梯，浅色部分
        private const int saturationStep2 = 5; // 饱和度阶梯，深色部分
        private const int brightnessStep1 = 5; // 亮度阶梯，浅色部分
        private const int brightnessStep2 = 15; // 亮度阶梯，深色部分
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

        public HEX[] Generate(HEX seed, ThemeGenerationOptions? options = default)
        {
            List<HEX> patterns = new();

            var rgb = seed.ToRGB();
            var hsv = seed.ToHSV();

            for (var i = lightColorCount; i > 0; i -= 1)
            {
                var mixedHsv = new HSV(
                    MixHue(hsv, i, true),
                    MixSaturation(hsv, i, true),
                    MixValue(hsv, i, true));

                patterns.Add(mixedHsv.ToHEX());
            }

            patterns.Add(seed);

            for (var i = 1; i <= darkColorCount; i += 1)
            {
                var mixedHsv = new HSV(
                    MixHue(hsv, i, false),
                    MixSaturation(hsv, i, false),
                    MixValue(hsv, i, false));

                patterns.Add(mixedHsv.ToHEX());
            }

            if (options?.Theme == PresetTheme.Dark)
            {
                var bgRgb = (options.BackgroundColor ?? new HEX("#141414")).ToRGB();

                return darkColorMap
                    .Select(x => MixRGB(bgRgb, patterns[x.Index].ToRGB(), x.Opacity * 100).ToHEX())
                    .ToArray();
            }
            else
            {
                return patterns.ToArray();
            }
        }

        private static int MixHue(HSV color, int amount, bool light)
        {
            int hue;

            // 根据色相不同，色相转向不同
            if (color.H >= 60 && color.H <= 240)
            {
                hue = light ? color.H - hueStep * amount : color.H + hueStep * amount;
            }
            else
            {
                hue = light ? color.H + hueStep * amount : color.H - hueStep * amount;
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

        private static int MixSaturation(HSV color, int amount, bool light)
        {
            // grey color don't change saturation
            if (color.H == 0 && color.S == 0)
            {
                return color.S;
            }

            int saturation;
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

            // Restrict the first light saturation <= 10
            if (light && amount == lightColorCount && saturation > 10)
            {
                saturation = 10;
            }

            saturation = Math.Clamp(saturation, 6, 100);

            return saturation;
        }

        private static int MixValue(HSV color, int amount, bool light)
        {
            int value = light
                ? color.V + brightnessStep1 * amount
                : color.V - brightnessStep2 * amount;

            return Math.Min(value, 100);
        }

        // Wrapper function ported from TinyColor.prototype.mix, not treeshakable.
        // Amount in range [0, 1]
        // Assume color1 & color2 has no alpha, since the following src code did so.
        private static RGB MixRGB(RGB rgb1, RGB rgb2, double amount)
        {
            if (amount > 1 || amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            var mix = (int v1, int v2) => (int)Math.Round((v2 - v1) * amount + v1);

            var r = mix(rgb1.R, rgb2.R);
            var g = mix(rgb1.G, rgb2.G);
            var b = mix(rgb1.B, rgb2.B);

            return new RGB(r, g, b);
        }

        public record ThemeGenerationOptions
        {
            public PresetTheme? Theme { get; set; }
            public bool Compact { get; set; }
            public HEX? BackgroundColor { get; set; }
        }

        public enum PresetTheme
        {
            Light, Dark
        }
    }
}