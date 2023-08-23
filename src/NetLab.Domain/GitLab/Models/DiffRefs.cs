using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{

    public class DiffRefs
    {
        [JsonPropertyName("base_sha")]
        public string BaseSha { get; set; }

        [JsonPropertyName("head_sha")]
        public string HeadSha { get; set; }

        [JsonPropertyName("start_sha")]
        public string StartSha { get; set; }
    }
}
