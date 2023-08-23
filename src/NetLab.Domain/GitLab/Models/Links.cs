using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{

    public class Links
    {
        [JsonPropertyName("self")]
        public Uri Self { get; set; }

        [JsonPropertyName("notes")]
        public Uri Notes { get; set; }

        [JsonPropertyName("award_emoji")]
        public Uri AwardEmoji { get; set; }

        [JsonPropertyName("project")]
        public Uri Project { get; set; }
    }
}
