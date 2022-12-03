using System.Text.RegularExpressions;

namespace BlazorCssIsolation;

//https://github.com/iamartyom/ColorHelper/blob/master/ColorHelper/Converter/ColorConverter.cs

//TODO: Support alpha?
public interface IColor : IConvertToHex, IConvertToHsv, IConvertToRgb, IConvertToHsl
{
    /// <summary>
    /// Sets the alpha value on the current color.
    /// </summary>
    /// <param name="alpha">Valid between 0 and 1.</param>
    /// <returns>A new color</returns>
    IColor ApplyAlpha(double alpha);

    /// <summary>
    /// Lighten the color a given amount, from 0 to 100. Providing 100 will always return white.
    /// </summary>
    /// <param name="brightness">Valid between 1 and 100</param>
    /// <returns>A new color</returns>
    IColor Lighten(int brightness);

    /// <summary>
    /// Darken the color a given amount, from 0 to 100. Providing 100 will always return black.
    /// </summary>
    /// <param name="brightness">Valid between 1 and 100</param>
    /// <returns>A new color</returns>
    IColor Darken(int brightness);

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

/// <summary>
/// Alpha is not supported at this stage
/// </summary>
public partial record HEX : IColor
{
    [GeneratedRegex("^([a-fA-F0-9]{3,4,6,8})$", RegexOptions.Compiled)]
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
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));

        var v = value.StartsWith("#") ? value[1..] : value;

        if (!HexRegex.IsMatch(v))
            throw new ArgumentException("Only the three-value and six-value syntax are supported");

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
        throw new NotImplementedException();
    }

    public IColor Lighten(int brightness)
    {
        throw new NotImplementedException();
    }

    public IColor Darken(int brightness)
    {
        throw new NotImplementedException();
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
    public RGB(int r, int g, int b, double? a = default)
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

    public int R { get; }
    public int G { get; }
    public int B { get; }
    public double? A { get; }

    public IColor Darken(int brightness)
    {
        throw new NotImplementedException();
    }

    public IColor Lighten(int brightness)
    {
        throw new NotImplementedException();
    }

    public IColor ApplyAlpha(double alpha)
    {
        throw new NotImplementedException();
    }

    public HEX ToHEX()
    {
        return new HEX($"{R:x2}{G:x2}{B:x2}");
    }

    public HSL ToHSL()
    {
        double modifiedR, modifiedG, modifiedB, min, max, delta, h, s, l;

        modifiedR = R / 255.0;
        modifiedG = G / 255.0;
        modifiedB = B / 255.0;

        min = new[] { modifiedR, modifiedG, modifiedB }.Min();
        max = new[] { modifiedR, modifiedG, modifiedB }.Max();
        delta = max - min;
        l = (min + max) / 2;

        if (delta == 0)
        {
            h = 0;
            s = 0;
        }
        else
        {
            s = (l <= 0.5) ? (delta / (min + max)) : (delta / (2 - max - min));

            if (modifiedR == max)
            {
                h = (modifiedG - modifiedB) / 6 / delta;
            }
            else if (modifiedG == max)
            {
                h = (1.0 / 3) + ((modifiedB - modifiedR) / 6 / delta);
            }
            else
            {
                h = (2.0 / 3) + ((modifiedR - modifiedG) / 6 / delta);
            }

            h = (h < 0) ? ++h : h;
            h = (h > 1) ? --h : h;
        }

        return new HSL(
            (int)Math.Round(h * 360),
            (int)Math.Round(s * 100),
            (int)Math.Round(l * 100));
    }

    public HSV ToHSV()
    {
        var hsl = ToHSL();

        double modifiedS, modifiedL, hsvS, hsvV;

        modifiedS = hsl.S / 100.0;
        modifiedL = hsl.L / 100.0;

        hsvV = modifiedL + modifiedS * Math.Min(modifiedL, 1 - modifiedL);

        hsvS = (hsvV == 0) ? 0 : 2 * (1 - modifiedL / hsvV);

        return new HSV(hsl.H, (int)Math.Round(hsvS * 100), (int)Math.Round(hsvV * 100));
    }

    public RGB ToRGB()
    {
        return this;
    }

    public string AsString()
    {
        return $"rgb({R}, {G}, {B})";
    }
}

public record HSV : IColor
{
    /// <summary>
    /// e.g. hsv(120, 100%, 50%) = new HSV(120, 100, 50)
    /// </summary>
    /// <param name="h">Hue value from 0 to 360</param>
    /// <param name="s">Saturation percentage from 0 to 100</param>
    /// <param name="v">Value (or Brightness) percentage from 0 to 100</param>
    public HSV(int h, int s, int v)
    {
        if (h < 0 || h > 360) throw new ArgumentException(nameof(h));
        if (s < 0 || s > 100) throw new ArgumentException(nameof(s));
        if (v < 0 || v > 100) throw new ArgumentException(nameof(v));

        H = h;
        S = s;
        V = v;
    }

    public int H { get; }
    public int S { get; }
    public int V { get; }

    public IColor Darken(int brightness)
    {
        throw new NotImplementedException();
    }

    public IColor Lighten(int brightness)
    {
        throw new NotImplementedException();
    }

    public IColor ApplyAlpha(double alpha)
    {
        throw new NotImplementedException();
    }

    public HEX ToHEX()
    {
        return ToRGB().ToHEX();
    }

    public HSL ToHSL()
    {
        double modifiedS, modifiedV, hslS, hslL;

        modifiedS = S / 100.0;
        modifiedV = V / 100.0;

        hslL = modifiedV * (1 - modifiedS / 2);
        hslS = (hslL == 0 || hslL == 1) ? 0 : (modifiedV - hslL) / Math.Min(hslL, 1 - hslL);

        return new HSL(H, (int)Math.Round(hslS * 100), (int)Math.Round(hslL * 100));
    }

    public HSV ToHSV()
    {
        return this;
    }

    public RGB ToRGB()
    {
        return ToHSL().ToRGB();
    }

    public string AsString()
    {
        return $"hsl({H} {S}% {V}%)";
    }
}

public record HSL : IColor
{
    /// <summary>
    /// e.g. hsl(120, 100%, 50%) = new HSV(120, 100, 50)
    /// </summary>
    /// <param name="h">Hue degree from 0 to 360</param>
    /// <param name="s">Saturation percentage from 0 to 100</param>
    /// <param name="l">Lightness percentage from 0 to 100</param>
    public HSL(int h, int s, int l)
    {
        if (h < 0 || h > 360) throw new ArgumentException(nameof(h));
        if (s < 0 || s > 100) throw new ArgumentException(nameof(s));
        if (l < 0 || l > 100) throw new ArgumentException(nameof(l));

        H = h;
        S = s;
        L = l;
    }

    public int H { get; }
    public int S { get; }
    public int L { get; }

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
        double modifiedH, modifiedS, modifiedL, r = 1, g = 1, b = 1, q, p;

        modifiedH = H / 360.0;
        modifiedS = S / 100.0;
        modifiedL = L / 100.0;

        q = (modifiedL < 0.5) ? modifiedL * (1 + modifiedS) : modifiedL + modifiedS - modifiedL * modifiedS;
        p = 2 * modifiedL - q;

        if (modifiedL == 0)  // if the lightness value is 0 it will always be black
        {
            r = 0;
            g = 0;
            b = 0;
        }
        else if (modifiedS != 0)
        {
            r = GetHue(p, q, modifiedH + 1.0 / 3);
            g = GetHue(p, q, modifiedH);
            b = GetHue(p, q, modifiedH - 1.0 / 3);
        }

        return new RGB((int)Math.Round(r * 255), (int)Math.Round(g * 255), (int)Math.Round(b * 255));
    }

    public IColor ApplyAlpha(double alpha)
    {
        throw new NotImplementedException();
    }

    public IColor Lighten(int brightness)
    {
        throw new NotImplementedException();
    }

    public IColor Darken(int brightness)
    {
        throw new NotImplementedException();
    }

    public string AsString()
    {
        return $"hsv({H} {S}% {L}%)";
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
}