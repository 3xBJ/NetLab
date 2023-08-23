using NetLab.Domain.GitLab.Clients.Issues;
using NetLab.Domain.GitLab.Clients.Labels;
using NetLab.Domain.GitLab.Clients.MergeRequests;
using NetLab.Domain.GitLab.Clients.Milestones;

namespace NetLab.Domain.GitLab.Clients
{
    /// <summary>
    /// Represents a client for interacting with various aspects of the GitLab service.
    /// </summary>
    public interface IGitLabClient
    {
        /// <summary>
        /// Gets a client for working with GitLab issues.
        /// </summary>
        IIssueClient Issue { get; }

        /// <summary>
        /// Gets a client for working with GitLab merge requests.
        /// </summary>
        IMergeRequestClient MergeRequest { get; }

        /// <summary>
        /// Gets a client for working with GitLab milestones.
        /// </summary>
        IMilestonesClient Milestone { get; }

        /// <summary>
        /// Gets a client for working with GitLab labels.
        /// </summary>
        ILabelClient Labels { get; }
    }
}
