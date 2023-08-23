using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{
    public class Asset
    {
        [JsonPropertyName("count")]
        public long Count { get; set; }

        [JsonPropertyName("sources")]
        public Source[] Sources { get; set; }

        [JsonPropertyName("links")]
        public object[] Links { get; set; }
    }
}
