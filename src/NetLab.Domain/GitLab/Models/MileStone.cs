using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{

    public class Milestone
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("iid")]
        public long Iid { get; set; }

        [JsonPropertyName("project_id")]
        public long ProjectId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonPropertyName("due_date")]
        public DateTimeOffset? DueDate { get; set; }

        [JsonPropertyName("start_date")]
        public DateTimeOffset? StartDate { get; set; }

        [JsonPropertyName("expired")]
        public bool? Expired { get; set; }

        [JsonPropertyName("web_url")]
        public Uri WebUrl { get; set; }
    }
}
