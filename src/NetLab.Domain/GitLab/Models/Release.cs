using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{

    public class Release
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("tag_name")]
        public string TagName { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("description_html")]
        public string DescriptionHtml { get; set; }

        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("released_at")]
        public DateTimeOffset ReleasedAt { get; set; }

        [JsonPropertyName("author")]
        public Author Author { get; set; }

        [JsonPropertyName("commit")]
        public Commit Commit { get; set; }

        [JsonPropertyName("upcoming_release")]
        public bool UpcomingRelease { get; set; }

        [JsonPropertyName("milestones")]
        public Milestone[] Milestones { get; set; }

        [JsonPropertyName("commit_path")]
        public string CommitPath { get; set; }

        [JsonPropertyName("tag_path")]
        public string TagPath { get; set; }

        [JsonPropertyName("assets")]
        public Asset Assets { get; set; }

        [JsonPropertyName("evidences")]
        public Evidence[] Evidences { get; set; }

        [JsonPropertyName("_links")]
        public Links Links { get; set; }
    }
}
