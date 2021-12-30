using System.Text.Json;

namespace LogConvert.Cli.Helper
{
    public static class JsonHelpers
    {
        public static string ToJson(this object item)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonObj = JsonSerializer.Serialize(item, options);

            return jsonObj;
        }
    }
}