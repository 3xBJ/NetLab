using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{

    public class Source
    {
        [JsonPropertyName("format")]
        public string Format { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }
    }

}
