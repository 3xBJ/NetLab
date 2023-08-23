using NetLab.Domain.GitLab.Clients;
using NetLab.Domain.GitLab.Clients.Milestones;
using NetLab.GitLab.Modelos.GitLab;
using NetLab.GitLab.Util.Wrappers.Http.Interfaces;
using NetLab.Infrastructure.Clients.Responses;
using NetLab.Infrastructure.Clients.REST;

namespace NetLab.Domain.Clients.REST
{
    /// <summary>
    /// Represents a client for working with milestones in a GitLab project.
    /// </summary>
    /// <remarks>
    /// https://docs.gitlab.com/ee/api/milestones.html
    /// </remarks>
    internal class MilestoneClient : BaseClient<Milestone, SelectMilestoneRequest>, IMilestonesClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MilestoneClient"/> class.
        /// </summary>
        /// <param name="httpClient">An instance of the paginated HTTP client.</param>
        internal MilestoneClient(IPaginatedHttpClient httpClient) : base(httpClient) { }

        /// <summary>
        /// Creates a new milestone in a GitLab project based on the provided options.
        /// </summary>
        /// <param name="projectId">The ID of the GitLab project.</param>
        /// <param name="options">The options to configure the new milestone.</param>
        /// <returns>
        /// A task representing the asynchronous operation and containing the response.
        /// </returns>
        public async Task<IResponse<string>> CreateAsync(int projectId, Action<NewMilestoneRequest> options)
        {
            NewMilestoneRequest req = RequestCreator<NewMilestoneRequest>.Create(options);
            string url = URLs.GetMilestonesUrl(projectId, string.Empty);

            return await httpClient.PostAsync(url, req);
        }

        /// <inheritdoc/>
        protected override string GetUrl(int projectId, string parameters) => URLs.GetMilestonesUrl(projectId, parameters);
    }
}
