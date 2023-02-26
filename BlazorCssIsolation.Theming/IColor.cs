using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorCssIsolation.Theming;

//https://github.com/iamartyom/ColorHelper/blob/master/ColorHelper/Converter/ColorConverter.cs

//TODO: Support alpha?
public interface IColor : IConvertToHex, IConvertToHsv, IConvertToRgb, IConvertToHsl
{
    /// <summary>
    /// Lighten the color a given amount, from 0 to 100. Providing 100 will always return white.
    /// </summary>
    /// <param name="brightness">Valid between 1 and 100</param>
    /// <returns>A new color</returns>
    IColor Lighten(double brightness);

    /// <summary>
    /// Darken the color a given amount, from 0 to 100. Providing 100 will always return black.
    /// </summary>
    /// <param name="brightness">Valid between 1 and 100</param>
    /// <returns>A new color</returns>
    IColor Darken(double brightness);

    /// <summary>
    /// Sets the alpha value on the current color.
    /// </summary>
    /// <param name="alpha">Valid between 0 and 1.</param>
    /// <returns>A new color</returns>
    IColor ApplyAlpha(double alpha);

    IColor ClampAlpha(IColor otherColor);

    string AsString();
}

public interface IConvertToHex
{
    HEX ToHEX();
}

public interface IConvertToRgb
{
    RGB ToRGB();
}

public interface IConvertToHsv
{
    HSV ToHSV();
}

public interface IConvertToHsl
{
    HSL ToHSL();
}

public partial record HEX : IColor
{
    [GeneratedRegex("^(?:[0-9a-fA-F]{3,4}){1,2}$", RegexOptions.Compiled)]
    private static partial Regex HexPatternRegex();
    private static readonly Regex HexRegex = HexPatternRegex();

    public HEX(string value)
    {
        Value = Parse(value);
    }

    public string Value { get; }

    public HEX ToHEX()
    {
        return this;
    }

    public HSL ToHSL()
    {
        return ToRGB().ToHSL();
    }

    public HSV ToHSV()
    {
        return ToRGB().ToHSV();
    }

    public RGB ToRGB()
    {
        var value = Convert.ToInt32(Value, 16);

        return new RGB(
            value >> 16 & 255,
            value >> 8 & 255,
            value & 255);
    }

    private static string Parse(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException(nameof(value));

        var v = value.StartsWith("#") ? value[1..] : value;

        if (!HexRegex.IsMatch(v))
            throw new ArgumentException($"Invalid HEX value: {value}");

        v = v.Length switch
        {
            3 => $"{v[0]}{v[0]}{v[1]}{v[1]}{v[2]}{v[2]}",
            4 => $"{v[0]}{v[0]}{v[1]}{v[1]}{v[2]}{v[2]}{v[3]}{v[3]}",
            _ => v,
        };

        return v.ToLowerInvariant();
    }

    public IColor ApplyAlpha(double alpha)
    {
        if (alpha < 0 || alpha > 1) throw new ArgumentOutOfRangeException(nameof(alpha));

        var alphaValue = (int)Math.Ceiling(alpha * 255);
        var alphaHex = $"{alphaValue:x2}";
        if (Value.Length == 6)
        {
            return new HEX($"{Value}{alphaHex}");
        }
        else
        {
            return new HEX($"{Value[0..6]}{alphaHex}");
        }
    }

    public IColor Lighten(double brightness)
    {
        if (brightness < 0 || brightness > 100)
            throw new ArgumentOutOfRangeException(nameof(brightness));

        var hsl = ToHSL();

        var amount = brightness == 0 ? 0 : brightness;

        var l = hsl.L + (amount / 100);

        l = Math.Clamp(l, 0, 1);

        return new HSL(hsl.H, hsl.S, l).ToHEX();
    }

    public IColor Darken(double brightness)
    {
        if (brightness < 0 || brightness > 100)
            throw new ArgumentOutOfRangeException(nameof(brightness));

        var hsl = ToHSL();

        var l = hsl.L;
        l -= brightness / 100d;
        l = Math.Clamp(l, 0, 1);

        hsl = (hsl with { L = l });
        var hex = hsl.ToHEX();
        return hex;
    }

    public IColor ClampAlpha(IColor otherColor)
    {
        return ToRGB().ClampAlpha(otherColor);
    }

    public string AsString()
    {
        return $"#{Value}";
    }
}

public record RGB : IColor
{
    /// <summary>
    /// e.g. rgb(255,0,0) = new RGB(255, 0, 0)
    /// </summary>
    /// <param name="r">Red value from 0 to 255</param>
    /// <param name="g">Green value from 0 to 255</param>
    /// <param name="b">Blue value from 0 to 255</param>
    /// <param name="a">Alpha value from 0 to 1</param>
    public RGB(double r, double g, double b, double? a = default)
    {
        if (r < 0 || r > 255) throw new ArgumentException(nameof(r));
        if (g < 0 || g > 255) throw new ArgumentException(nameof(g));
        if (b < 0 || b > 255) throw new ArgumentException(nameof(b));
        if (a < 0 || a > 1) throw new ArgumentException(nameof(a));

        R = r;
        G = g;
        B = b;
        A = a;
    }

    public double R { get; }
    public double G { get; }
    public double B { get; }
    public double? A { get; }

    public IColor Darken(double brightness)
    {
        throw new NotImplementedException();
    }

    public IColor Lighten(double brightness)
    {
        throw new NotImplementedException();
    }

    public IColor ApplyAlpha(double alpha)
    {
        throw new NotImplementedException();
    }

    public IColor ClampAlpha(IColor backgroundColor)
    {
        var fRgb = ToRGB();
        if (fRgb.A < 1) return this;

        var bRgb = backgroundColor.ToRGB();

        for (var fA = 0.01; fA <= 1; fA += 0.01)
        {
            var r = Math.Round((fRgb.R - bRgb.R * (1 - fA)) / fA, MidpointRounding.AwayFromZero);
            var g = Math.Round((fRgb.G - bRgb.G * (1 - fA)) / fA, MidpointRounding.AwayFromZero);
            var b = Math.Round((fRgb.B - bRgb.B * (1 - fA)) / fA, MidpointRounding.AwayFromZero);

            if (IsStableColor(r) && IsStableColor(g) && IsStableColor(b))
            {
                return new RGB(r, g, b, fA);
            }
        }

        return new RGB(fRgb.R, fRgb.G, fRgb.B, 1);
    }

    private static bool IsStableColor(double colorValue)
    {
        return colorValue >= 0 && colorValue <= 255;
    }

    public HEX ToHEX()
    {
        var r = (int)Math.Round(R, MidpointRounding.AwayFromZero);
        var g = (int)Math.Round(G, MidpointRounding.AwayFromZero);
        var b = (int)Math.Round(B, MidpointRounding.AwayFromZero);
        var a = A.HasValue ? (int)Math.Round(A.Value, MidpointRounding.AwayFromZero) : new int?();

        return a.HasValue ? new($"{r:x2}{g:x2}{b:x2}{a:x2}") : new($"{r:x2}{g:x2}{b:x2}");
    }

    public HSL ToHSL()
    {
        double r = R / 255.0;
        double g = G / 255.0;
        double b = B / 255.0;

        double min = new[] { r, g, b }.Min();
        double max = new[] { r, g, b }.Max();
        double delta = max - min;

        double h;
        double s;
        double l = (min + max) / 2;

        if (delta == 0)
        {
            h = 0;
            s = 0;
        }
        else
        {
            s = l > 0.5 ? (delta / (2 - max - min)) : (delta / (max + min));

            if (r == max)
            {
                h = (g - b) / delta + (g < b ? 6 : 0);
            }
            else if (g == max)
            {
                h = (b - r) / delta + 2;
            }
            else
            {
                h = (r - g) / delta + 4;
            }

            h /= 6;
        }

        return new HSL(h * 360, s, l);
    }

    public HSV ToHSV()
    {
        double r = R / 255d;
        double g = G / 255d;
        double b = B / 255d;

        double max = new[] { r, g, b }.Max();
        double min = new[] { r, g, b }.Min();
        double delta = max - min;

        double h;
        double s = max == 0 ? 0 : delta / max;
        double v = max;

        if (max == min)
        {
            h = 0d; // achromatic
        }
        else
        {
            if (max == r)
            {
                h = (g - b) / delta + (g < b ? 6 : 0);
            }
            else if (max == g)
            {
                h = (b - r) / delta + 2;
            }
            else
            {
                h = (r - g) / delta + 4;
            }

            h /= 6d;
        }

        return new HSV(h * 360, s, v);
    }

    public RGB ToRGB()
    {
        return this;
    }

    public string AsString()
    {
        return A.HasValue && A < 0 ? $"rgba({R}, {G}, {B}, {A})" : $"rgb({R}, {G}, {B})";
    }
}

public record HSV : IColor
{
    /// <summary>
    /// e.g. hsv(120, 100%, 50%) = new HSV(120, 100, 50)
    /// </summary>
    /// <param name="h">Hue value from 0 to 360</param>
    /// <param name="s">Saturation percentage from 0 to 1 or 100%</param>
    /// <param name="v">Value (or Brightness) percentage from 0 to 1 or 100%</param>
    public HSV(double h, double s, double v)
    {
        if (h < 0 || h > 360) throw new ArgumentOutOfRangeException(nameof(h));
        if (s < 0 || s > 1) throw new ArgumentOutOfRangeException(nameof(s));
        if (v < 0 || v > 1) throw new ArgumentOutOfRangeException(nameof(v));

        H = h;
        S = s;
        V = v;
    }

    public double H { get; }
    public double S { get; }
    public double V { get; }

    public IColor Darken(double brightness)
    {
        throw new NotImplementedException();
    }

    public IColor Lighten(double brightness)
    {
        throw new NotImplementedException();
    }

    public IColor ApplyAlpha(double alpha)
    {
        throw new NotImplementedException();
    }

    public IColor ClampAlpha(IColor otherColor)
    {
        throw new NotImplementedException();
    }

    public HEX ToHEX()
    {
        return ToRGB().ToHEX();
    }

    public HSL ToHSL()
    {
        return ToRGB().ToHSL();
    }

    public HSV ToHSV()
    {
        return this;
    }

    public RGB ToRGB()
    {
        double h = H / 360 * 6;
        double s = S;
        double v = V;

        int i = (int)Math.Floor(h);

        double f = h - i;
        double p = v * (1 - s);
        double q = v * (1 - f * s);
        double t = v * (1 - (1 - f) * s);

        int mod = i % 6;

        double r = new[] { v, q, p, p, t, v }[mod];
        double g = new[] { t, v, v, q, p, p }[mod];
        double b = new[] { p, p, t, v, v, q }[mod];

        return new RGB(r * 255, g * 255, b * 255);
    }

    public string AsString()
    {
        return $"hsv({H} {S * 100}% {V * 100}%)";
    }
}

public record HSL : IColor
{
    /// <summary>
    /// e.g. hsl(120, 100%, 50%) = new HSV(120, 100, 50)
    /// </summary>
    /// <param name="h">Hue degree from 0 to 360</param>
    /// <param name="s">Saturation percentage from 0 to 1 or 100%</param>
    /// <param name="l">Lightness percentage from 0 to 1 or 100%</param>
    public HSL(double h, double s, double l)
    {
        if (h < 0 || h > 360) throw new ArgumentOutOfRangeException(nameof(h));
        if (s < 0 || s > 1) throw new ArgumentOutOfRangeException(nameof(s));
        if (l < 0 || l > 1) throw new ArgumentOutOfRangeException(nameof(l));

        H = h;
        S = s;
        L = l;
    }

    public double H { get; init; }
    public double S { get; init; }
    public double L { get; init; }

    public HEX ToHEX()
    {
        return ToRGB().ToHEX();
    }

    public HSL ToHSL()
    {
        return this;
    }

    public HSV ToHSV()
    {
        return ToRGB().ToHSV();
    }

    public RGB ToRGB()
    {
        double r;
        double g;
        double b;

        double h = H;
        double s = S;
        double l = L;

        if (s == 0)
        {
            // achromatic
            g = l;
            b = l;
            r = l;
        }
        else
        {
            double q = l < 0.5 ? l * (1 + s) : l + s - l * s;
            double p = 2 * l - q;

            r = Hue2Rgb(p, q, h + 1 / 3);
            g = Hue2Rgb(p, q, h);
            b = Hue2Rgb(p, q, h - 1 / 3);
        }

        return new RGB(r * 255d, g * 255d, b * 255d);


        //double modifiedH, modifiedS, modifiedL, r = 1, g = 1, b = 1, q, p;

        //modifiedH = H / 360d;
        //modifiedS = S / 100d;
        //modifiedL = L / 100d;

        //q = (modifiedL < 0.5) ? modifiedL * (1 + modifiedS) : modifiedL + modifiedS - modifiedL * modifiedS;
        //p = 2 * modifiedL - q;

        //if (modifiedL == 0)  // if the lightness value is 0 it will always be black
        //{
        //    r = 0;
        //    g = 0;
        //    b = 0;
        //}
        //else if (modifiedS != 0)
        //{
        //    r = GetHue(p, q, modifiedH + 1.0 / 3);
        //    g = GetHue(p, q, modifiedH);
        //    b = GetHue(p, q, modifiedH - 1.0 / 3);
        //}

        //return new RGB(r * 255d, g * 255d, b * 255d);
    }

    public IColor ApplyAlpha(double alpha)
    {
        throw new NotImplementedException();
    }

    public IColor ClampAlpha(IColor otherColor)
    {
        throw new NotImplementedException();
    }

    public IColor Lighten(double brightness)
    {
        throw new NotImplementedException();
    }

    public IColor Darken(double brightness)
    {
        throw new NotImplementedException();
    }

    public string AsString()
    {
        return $"hsl({H} {S * 100}% {L * 100}%)";
    }

    private static double GetHue(double p, double q, double t)
    {
        double value = p;

        if (t < 0) t++;
        if (t > 1) t--;

        if (t < 1.0 / 6)
        {
            value = p + (q - p) * 6 * t;
        }
        else if (t < 1.0 / 2)
        {
            value = q;
        }
        else if (t < 2.0 / 3)
        {
            value = p + (q - p) * (2.0 / 3 - t) * 6;
        }

        return value;
    }

    private static double Hue2Rgb(double p, double q, double t)
    {
        if (t < 0)
        {
            t += 1;
        }

        if (t > 1)
        {
            t -= 1;
        }

        if (t < 1 / 6)
        {
            return p + (q - p) * (6 * t);
        }

        if (t < 1 / 2)
        {
            return q;
        }

        if (t < 2 / 3)
        {
            return p + (q - p) * (2 / 3 - t) * 6;
        }

        return p;
    }
}