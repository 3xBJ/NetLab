using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{

    public class References
    {
        [JsonPropertyName("short")]
        public string Short { get; set; }

        [JsonPropertyName("relative")]
        public string Relative { get; set; }

        [JsonPropertyName("full")]
        public string Full { get; set; }
    }
}
