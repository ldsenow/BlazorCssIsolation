namespace BlazorCssIsolation.Themes.Shared;

// TODO: Consider making each of these generation algorithm as an option
internal static class RadiiGenerator
{
    public static Radii Genereate(double baseUnit)
    {
        var radiusLG = baseUnit;
        var radiusSM = baseUnit;
        var radiusXS = baseUnit;
        var radiusOuter = baseUnit;

        // radiusLG
        if (baseUnit < 6 && baseUnit >= 5)
        {
            radiusLG = baseUnit + 1;
        }
        else if (baseUnit < 16 && baseUnit >= 6)
        {
            radiusLG = baseUnit + 2;
        }
        else if (baseUnit >= 16)
        {
            radiusLG = 16;
        }

        // radiusSM
        if (baseUnit < 7 && baseUnit >= 5)
        {
            radiusSM = 4;
        }
        else if (baseUnit < 8 && baseUnit >= 7)
        {
            radiusSM = 5;
        }
        else if (baseUnit < 14 && baseUnit >= 8)
        {
            radiusSM = 6;
        }
        else if (baseUnit < 16 && baseUnit >= 14)
        {
            radiusSM = 7;
        }
        else if (baseUnit >= 16)
        {
            radiusSM = 8;
        }

        // radiusXS
        if (baseUnit < 6 && baseUnit >= 2)
        {
            radiusXS = 1;
        }
        else if (baseUnit >= 6)
        {
            radiusXS = 2;
        }

        // radiusOuter
        if (baseUnit > 4 && baseUnit < 8)
        {
            radiusOuter = 4;
        }
        else if (baseUnit >= 8)
        {
            radiusOuter = 6;
        }

        return new Radii(
            BorderRadius: baseUnit > 16 ? 16 : baseUnit,
            BorderRadiusXS: radiusXS,
            BorderRadiusSM: radiusSM,
            BorderRadiusLG: radiusLG,
            BorderRadiusOuter: radiusOuter);
    }
}

public record Radii(
    double BorderRadius,
    double BorderRadiusXS,
    double BorderRadiusSM,
    double BorderRadiusLG,
    double BorderRadiusOuter);
