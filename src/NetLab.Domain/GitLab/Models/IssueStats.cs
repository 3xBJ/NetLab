using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{

    public partial class IssueStats
    {
        [JsonPropertyName("total")]
        public long Total { get; set; }

        [JsonPropertyName("closed")]
        public long Closed { get; set; }
    }
}
