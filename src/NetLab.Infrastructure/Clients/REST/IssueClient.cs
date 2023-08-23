using NetLab.Domain.GitLab.Clients.Issues;
using NetLab.GitLab.Modelos.GitLab;
using NetLab.GitLab.Util.Wrappers.Http.Interfaces;
using NetLab.Infrastructure.Clients.Responses;
using NetLab.Infrastructure.Clients.REST;
using NetLab.Infrastructure.Parameters;
using NetLab.Modelos.Entidades.GitLab;

namespace NetLab.Domain.Clients.REST
{
    /// <summary>
    /// Represents a client for interacting with GitLab issues using asynchronous REST operations.
    /// </summary>
    /// <remarks>
    /// https://docs.gitlab.com/ee/api/issues.html
    /// </remarks>
    internal sealed class IssueClient : BaseClient<Issue, SelectIssueRequest>, IIssueClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssueClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client used to perform paginated requests.</param>
        internal IssueClient(IPaginatedHttpClient httpClient) : base(httpClient) { }

        /// <summary>
        /// Asynchronously retrieves statistics for an issue from a project.
        /// </summary>
        /// <param name="projectId">The identifier of the project.</param>
        /// <param name="options">An action to customize the issue statistics request.</param>
        /// <returns>
        /// An asynchronous response containing statistics for the requested issue.
        /// </returns>
        public async Task<IResponse<IssueStatistics>> GetStatisticsAsync(int projectId, Action<SelectIssueStatisticsRequest> options)
        {
            string parameters = ParameterSerializer.Serialize(options);
            string uri = URLs.GetIssueStatisticsUrl(projectId, parameters);

            return await httpClient.GetAsync<IssueStatistics>(uri);
        }

        /// <inheritdoc/>
        protected override string GetUrl(int projectId, string parameters) => URLs.GetIssueUrl(projectId, parameters);
    }
}
