using NetLab.Domain.Parameters;

namespace NetLab.Domain.GitLab.Clients.Issues
{
    public class SelectIssueStatisticsRequest
    {
        [Parameter("labels")]
        public IList<string> Labels { get; set; }

        [Parameter("created_before")]
        public DateTime? AntesDe { get; set; }

        [Parameter("created_after")]
        public DateTime? DepoisDe { get; set; }
    }
}
