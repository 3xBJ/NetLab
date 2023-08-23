using NetLab.GitLab.Modelos.GitLab;
using NetLab.Infrastructure.Clients.Responses;

namespace NetLab.Domain.GitLab.Clients.Milestones
{
    public interface IMilestonesClient : IBaseClient<Milestone, SelectMilestoneRequest>
    {
        Task<IResponse<string>> CreateAsync(int projectId, Action<NewMilestoneRequest> options);
    }
}
