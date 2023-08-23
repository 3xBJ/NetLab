using NetLab.Domain.GitLab.Clients.Labels;
using NetLab.Domain.GitLab.Clients.MergeRequests;
using NetLab.GitLab.Modelos.GitLab;
using NetLab.GitLab.Util.Wrappers.Http.Interfaces;
using NetLab.Infrastructure.Clients.Responses;
using NetLab.Infrastructure.Clients.REST;
using NetLab.Infrastructure.Parameters;

namespace NetLab.Domain.Clients.REST
{
    /// <summary>
    /// Represents a client for retrieving merge requests from a project using asynchronous operations.
    /// </summary>
    /// <remarks>
    /// https://docs.gitlab.com/ee/api/merge_requests.html
    /// </remarks>
    internal class MergeRequestClient : BaseClient<MergeRequest, SelectMergeRequest>, IMergeRequestClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MergeRequestClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client used to perform paginated requests.</param>
        internal MergeRequestClient(IPaginatedHttpClient httpClient) : base(httpClient) { }

        /// <summary>
        /// Asynchronously retrieves a sequence of merge requests related to a specific project and issue.
        /// </summary>
        /// <param name="projectId">The identifier of the project.</param>
        /// <param name="issueId">The identifier of the issue.</param>
        /// <param name="options">An action to customize the merge request selection.</param>
        /// <returns>
        /// An asynchronous enumerable of responses containing lists of merge requests.
        /// </returns>
        public async IAsyncEnumerable<IResponse<IList<MergeRequest>>> GetAsync(int projectId, long issueId, Action<SelectMergeRequest> options)
        {
            string parameters = ParameterSerializer.Serialize(options);
            string url = URLs.GetRelatedMRUrl(projectId, issueId, parameters);

            await foreach (IResponse<IList<MergeRequest>> response in  this.httpClient.GetPagesAsync<MergeRequest>(url))
            {
                yield return response;
            }
        }

        /// <inheritdoc/>
        protected override string GetUrl(int projectId, string parameters) => URLs.GetMergeRequestUrl(projectId, parameters);
    }
}
