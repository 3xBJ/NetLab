using NetLab.Domain.Parameters;
using NetLab.GitLab.Modelos.GitLab;

namespace NetLab.Domain.GitLab.Clients.Milestones
{
    public class SelectMilestoneRequest
    {
        [Parameter("id")]
        public int Id { get; set; }

        [Parameter("iids")]
        public int[] Issues { get; set; }

        [Parameter("state")]
        public MilestoneState State { get; set; }

        [Parameter("title")]
        public string Title { get; set; }
    }
}
