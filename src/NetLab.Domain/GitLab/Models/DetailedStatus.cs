using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{

    public class DetailedStatus
    {
        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("group")]
        public string Group { get; set; }

        [JsonPropertyName("tooltip")]
        public string Tooltip { get; set; }

        [JsonPropertyName("has_details")]
        public bool HasDetails { get; set; }

        [JsonPropertyName("details_path")]
        public string DetailsPath { get; set; }

        [JsonPropertyName("illustration")]
        public object Illustration { get; set; }

        [JsonPropertyName("favicon")]
        public string Favicon { get; set; }
    }
}
