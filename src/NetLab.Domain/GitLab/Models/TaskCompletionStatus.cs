using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{

    public class TaskCompletionStatus
    {
        [JsonPropertyName("count")]
        public long Count { get; set; }

        [JsonPropertyName("completed_count")]
        public long CompletedCount { get; set; }
    }
}
