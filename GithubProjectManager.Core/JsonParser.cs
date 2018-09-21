using Newtonsoft.Json;

namespace GithubProjectManager.Core
{
    public static class JsonParser<T>
    {
        public static T FromJson(string json) => JsonConvert.DeserializeObject<T>(json, Converter.Settings);
    }
}