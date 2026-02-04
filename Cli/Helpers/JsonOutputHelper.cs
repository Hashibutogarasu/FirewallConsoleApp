using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace FirewallConsoleApp.Cli.Helpers
{
    public static class JsonOutputHelper
    {
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };

        public static string Serialize<T>(T value)
        {
            return JsonSerializer.Serialize(value, _options);
        }
    }
}
