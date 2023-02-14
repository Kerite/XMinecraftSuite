using System.Text.Json;

namespace XMinecraftSuite.Core
{
    public static class Utils
    {
        public static string ToSnakeCase(this string str)
        { return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? $"_{x}" : x.ToString())).ToLower(); }
    }

    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) { return name.ToSnakeCase(); }
        public static SnakeCaseNamingPolicy Instance { get; } = new SnakeCaseNamingPolicy();
    }
}
