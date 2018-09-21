using System;
using Newtonsoft.Json;

namespace GithubProjectManager.Core.Resources
{
    public class ColumnsResource
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("project_url")]
        public Uri ProjectUrl { get; set; }

        [JsonProperty("cards_url")]
        public Uri CardsUrl { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("node_id")]
        public string NodeId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }
}