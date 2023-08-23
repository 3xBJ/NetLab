using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace NetLab.GitLab.Modelos.GitLab
{

    public class ProjectAccess
    {
        [JsonPropertyName("access_level")]
        public long AccessLevel { get; set; }

        [JsonPropertyName("notification_level")]
        public long NotificationLevel { get; set; }
    }
}
