using NetLab.Domain.Parameters;
using NetLab.GitLab.Modelos.GitLab;

namespace NetLab.Domain.GitLab.Clients.MergeRequests
{
    public class SelectMergeRequest
    {
        [Parameter("state")]
        public MergeState Status { get; set; }

        [Parameter("milestone")]
        public string MileStone { get; set; }

        [Parameter("labels")]
        public IEnumerable<string> Labels { get; set; }

        [Parameter("created_before")]
        public DateTime? AntesDe { get; set; }

        [Parameter("created_after")]
        public DateTime? DepoisDe { get; set; }
    }
}
