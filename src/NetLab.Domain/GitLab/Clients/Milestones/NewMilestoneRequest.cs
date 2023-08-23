using System.Text.Json.Serialization;

namespace NetLab.Domain.GitLab.Clients.Milestones
{
    public class NewMilestoneRequest
    {
        [JsonPropertyName("title")]
        public string Titulo { get; set; }

        [JsonPropertyName("description")]
        public string Descricao { get; set; }

        [JsonPropertyName("due_date")]
        public DateTime? Vencimento { get; set; }

        [JsonPropertyName("start_date")]
        public DateTime? Inicio { get; set; }
    }
}
