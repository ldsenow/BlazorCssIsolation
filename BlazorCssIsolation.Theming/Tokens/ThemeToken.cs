using BlazorCssIsolation.Theming.Themes;
using System.Reflection;

namespace BlazorCssIsolation.Theming.Tokens;

public record ThemeToken : AliasToken
{
    public ThemeToken(AliasToken original) : base(original)
    {
    }

    public DesignTokenCollection GetDesignTokens()
    {
        var collection = new DesignTokenCollection();
        var props = GetSortedProperties<AliasToken>();

        foreach (var prop in props)
        {
            collection.Set(prop.Name, prop.GetValue(this));
        }

        return collection;
    }

    public IReadOnlyCollection<DesignTokenChange> CompareChanges(ThemeToken target)
    {
        var sourceTokens = GetDesignTokens();
        var targetTokens = target.GetDesignTokens();

        var allKeys = sourceTokens.Keys.Concat(targetTokens.Keys)
            .Distinct().OrderBy(x => x).ToList();

        var changeSet = allKeys.Select(x =>
        {
            var sourceContains = sourceTokens.TryGetValue(x, out var sourceValue);
            var targetContains = targetTokens.TryGetValue(x, out var targetValue);
            var keyDiff = sourceContains != targetContains;
            var valueDiff = sourceValue != targetValue;

            if (!keyDiff && !valueDiff) return null;

            var status = ChangeStatus.Modified;

            if (keyDiff)
            {
                status = sourceContains ? ChangeStatus.Removed : ChangeStatus.Added;
            }

            return new DesignTokenChange(
                key: x,
                status: status,
                sourceValue: sourceValue,
                targetValue: targetValue);
        }).Where(x => x != null).Cast<DesignTokenChange>().ToList();

        return changeSet.AsReadOnly();
    }

    private static PropertyInfo[] GetSortedProperties<T>()
    {
        return typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .OrderBy(x => x.Name)
            .ToArray();
    }
}

public record DesignTokenChange
{
    public DesignTokenChange(string key, ChangeStatus status, DesignToken? sourceValue, DesignToken? targetValue)
    {
        Key = key;
        Status = status;
        SourceValue = sourceValue;
        TargetValue = targetValue;
    }

    public string Key { get; init; }
    public ChangeStatus Status { get; init; }
    public DesignToken? SourceValue { get; init; }
    public DesignToken? TargetValue { get; init; }
}

public enum ChangeStatus
{
    Modified, Removed, Added
}
