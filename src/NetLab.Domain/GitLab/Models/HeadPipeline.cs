using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{

    public class HeadPipeline
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("sha")]
        public string Sha { get; set; }

        [JsonPropertyName("ref")]
        public string Ref { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonPropertyName("web_url")]
        public Uri WebUrl { get; set; }

        [JsonPropertyName("before_sha")]
        public string BeforeSha { get; set; }

        [JsonPropertyName("tag")]
        public bool Tag { get; set; }

        [JsonPropertyName("yaml_errors")]
        public string YamlErrors { get; set; }

        [JsonPropertyName("user")]
        public Assignee User { get; set; }

        [JsonPropertyName("started_at")]
        public DateTimeOffset? StartedAt { get; set; }

        [JsonPropertyName("finished_at")]
        public DateTimeOffset? FinishedAt { get; set; }

        [JsonPropertyName("committed_at")]
        public object CommittedAt { get; set; }

        [JsonPropertyName("duration")]
        public long? Duration { get; set; }

        [JsonPropertyName("coverage")]
        public object Coverage { get; set; }

        [JsonPropertyName("detailed_status")]
        public DetailedStatus DetailedStatus { get; set; }
    }
}
