using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{

    public class IssueStatistics
    {
        [JsonPropertyName("statistics")]
        public Statistics Statistics { get; set; }
    }


    public class Statistics
    {
        [JsonPropertyName("counts")]
        public Counts Counts { get; set; }
    }


    public class Counts
    {
        [JsonPropertyName("all")]
        public long All { get; set; }

        [JsonPropertyName("closed")]
        public long Closed { get; set; }

        [JsonPropertyName("opened")]
        public long Opened { get; set; }
    }
}
