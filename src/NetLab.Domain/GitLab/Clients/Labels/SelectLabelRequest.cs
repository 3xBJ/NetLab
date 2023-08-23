using NetLab.Domain.Parameters;

namespace NetLab.Domain.GitLab.Clients.Labels
{
    public class SelectLabelRequest
    {
        [Parameter("with_counts")]
        public bool IncluirContador { get; set; }

        [Parameter("include_ancestor_groups")]
        public bool IncluirGruposAncestrais { get; set; } = true;

        [Parameter("search")]
        public string Busca { get; set; }
    }
}
