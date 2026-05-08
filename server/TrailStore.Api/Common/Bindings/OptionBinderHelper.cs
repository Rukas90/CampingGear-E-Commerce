namespace TrailStore.Api.Common.Bindings;

public static class OptionBinderHelper
{
    public static Dictionary<string, string>? ParseOptions(HttpContext context)
    {
        var option = context.Request.Query
            .Where(q => q.Key.StartsWith("option[") && q.Key.EndsWith(']'))
            .ToDictionary(
                q => q.Key[7..^1],
                q => q.Value.ToString());

        return option.Count > 0 ? option : null;
    }
}