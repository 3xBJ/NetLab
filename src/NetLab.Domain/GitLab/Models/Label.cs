using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{

    public class Label
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("description_html")]
        public string DescriptionHtml { get; set; }

        [JsonPropertyName("text_color")]
        public string TextColor { get; set; }

        [JsonPropertyName("subscribed")]
        public bool Subscribed { get; set; }

        [JsonPropertyName("priority")]
        public object Priority { get; set; }

        [JsonPropertyName("is_project_label")]
        public bool IsProjectLabel { get; set; }
    }
}
