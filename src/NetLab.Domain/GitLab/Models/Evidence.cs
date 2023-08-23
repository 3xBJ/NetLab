using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{

    public class Evidence
    {
        [JsonPropertyName("sha")]
        public string Sha { get; set; }

        [JsonPropertyName("filepath")]
        public Uri Filepath { get; set; }

        [JsonPropertyName("collected_at")]
        public DateTimeOffset CollectedAt { get; set; }
    }
}
