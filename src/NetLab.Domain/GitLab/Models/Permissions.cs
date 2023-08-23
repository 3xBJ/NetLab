using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{

    public class Permissions
    {
        [JsonPropertyName("project_access")]
        public ProjectAccess ProjectAccess { get; set; }

        [JsonPropertyName("group_access")]
        public object GroupAccess { get; set; }
    }
}
