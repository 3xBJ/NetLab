using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{

    public class ReleasesRegister
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("tag_name")]
        public string TagName { get; set; }

        [JsonPropertyName("milestones")]
        public string[] Milestones { get; set; }

        [JsonPropertyName("ref")]
        public string VersionBranch { get; set; }
    }
}
