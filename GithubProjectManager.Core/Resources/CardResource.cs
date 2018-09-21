using System;
using Newtonsoft.Json;

namespace GithubProjectManager.Core.Resources
{
    public class CardResource
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("node_id")]
        public string NodeId { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("creator")]
        public CreatorResource CreatorResource { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("column_url")]
        public Uri ColumnUrl { get; set; }

        [JsonProperty("content_url")]
        public Uri ContentUrl { get; set; }

        [JsonProperty("project_url")]
        public Uri ProjectUrl { get; set; }
    }
}