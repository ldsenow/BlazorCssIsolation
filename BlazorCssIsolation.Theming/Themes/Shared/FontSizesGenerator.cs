namespace BlazorCssIsolation.Themes.Shared;

// TODO: Consider making each of these generation algorithm as an option
// https://zhuanlan.zhihu.com/p/32746810
internal static class FontSizesGenerator
{
    public static FontSize[] Genereate(double baseUnit)
    {
        var sizes = Enumerable.Range(0, 10).Select(idx =>
        {
            if (idx == 1) return baseUnit;

            var i = idx - 1;

            var b = baseUnit * Math.Pow(2.71828, (i / 5.0));
            var s = idx > 1 ? Math.Floor(b) : Math.Ceiling(b);

            // Convert to even
            return Math.Floor(s / 2.0) * 2;
        }).ToList();

        return sizes.Select(size =>
        {
            var height = size + 8;
            var lineHeight = height / size;
            return new FontSize(size, lineHeight);
        }).ToArray();
    }
}

public record FontSize(double Size, double LineHeight);
