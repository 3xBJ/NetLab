using NetLab.Domain.Parameters;
using NetLab.GitLab.Modelos.GitLab;

namespace NetLab.Domain.GitLab.Clients.Issues
{
    public class SelectIssueRequest
    {
        [Parameter("state")]
        public StatusIssue State { get; set; }

        [Parameter("iids")]
        public IEnumerable<int> Issues { get; set; }

        [Parameter("milestone")]
        public string TituloMileStones { get; set; }

        [Parameter("labels")]
        public IList<string> Labels { get; set; }

        [Parameter("created_before")]
        public DateTime? AntesDe { get; set; }

        [Parameter("created_after")]
        public DateTime? DepoisDe { get; set; }
    }
}
