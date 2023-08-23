using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{

    public class TimeStats
    {
        [JsonPropertyName("time_estimate")]
        public long TimeEstimate { get; set; }

        [JsonPropertyName("total_time_spent")]
        public long TotalTimeSpent { get; set; }

        [NotMapped]
        [JsonPropertyName("human_time_estimate")]
        public object HumanTimeEstimate { get; set; }

        [NotMapped]
        [JsonPropertyName("human_total_time_spent")]
        public object HumanTotalTimeSpent { get; set; }
    }
}
