using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{

    public class User
    {
        [JsonPropertyName("can_merge")]
        public bool CanMerge { get; set; }
    }
}
