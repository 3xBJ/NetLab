using NetLab.Domain.GitLab.Clients;
using NetLab.Domain.GitLab.Clients.Issues;
using NetLab.Domain.GitLab.Clients.Labels;
using NetLab.Domain.GitLab.Clients.MergeRequests;
using NetLab.Domain.GitLab.Clients.Milestones;

namespace NetLab.GitLab
{
    /// <inheritdoc/>
    internal class GitLabClient : IGitLabClient
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="GitLabClient"/> class with the provided clients for various GitLab aspects.
        /// </summary>
        /// <param name="issueClient">The client for working with GitLab issues.</param>
        /// <param name="mergeRequestClient">The client for working with GitLab merge requests.</param>
        /// <param name="milestonesClient">The client for working with GitLab milestones.</param>
        /// <param name="labelClient">The client for working with GitLab labels.</param>
        internal GitLabClient(IIssueClient issueClient, IMergeRequestClient mergeRequestClient, IMilestonesClient milestonesClient, ILabelClient labelClient)
        {
            Issue = issueClient ?? throw new ArgumentNullException(nameof(issueClient));
            MergeRequest = mergeRequestClient ?? throw new ArgumentNullException(nameof(mergeRequestClient));
            Milestone = milestonesClient ?? throw new ArgumentNullException(nameof(milestonesClient));
            Labels = labelClient ?? throw new ArgumentNullException(nameof(labelClient));
        }

        /// <inheritdoc/>
        public IIssueClient Issue { get; }

        /// <inheritdoc/>
        public IMergeRequestClient MergeRequest { get; }

        /// <inheritdoc/>
        public IMilestonesClient Milestone { get; }

        /// <inheritdoc/>
        public ILabelClient Labels { get; }
    }
}
