using System.Text.Json;

namespace _4kTiles_Backend.Tests.Helpers
{
    public static class JsonHelper
    {
        public static string Serialize<T>(this T obj)
        {
            return JsonSerializer.Serialize(obj);
        }
    }
}