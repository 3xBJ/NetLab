using NetLab.GitLab.Modelos.GitLab;
using NetLab.Infrastructure.Clients.Responses;
using NetLab.Modelos.Entidades.GitLab;

namespace NetLab.Domain.GitLab.Clients.Issues
{
    /// <summary>
    /// Represents a client for interacting with GitLab issues.
    /// </summary>
    public interface IIssueClient : IBaseClient<Issue, SelectIssueRequest>
    {
        /// <summary>
        /// Asynchronously retrieves statistics related to GitLab issues for the specified project and options.
        /// </summary>
        /// <param name="projectId">The ID of the project associated with the issues.</param>
        /// <param name="options">An action to configure the request for specific issue statistics.</param>
        /// <returns>
        /// An asynchronous task representing the response containing issue statistics.
        /// </returns>
        Task<IResponse<IssueStatistics>> GetStatisticsAsync(int projectId, Action<SelectIssueStatisticsRequest> options);
    }
}
