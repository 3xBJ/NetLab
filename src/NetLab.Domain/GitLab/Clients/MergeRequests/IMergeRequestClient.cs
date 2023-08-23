using NetLab.GitLab.Modelos.GitLab;
using NetLab.Infrastructure.Clients.Responses;

namespace NetLab.Domain.GitLab.Clients.MergeRequests
{
    /// <summary>
    /// Represents a client for interacting with GitLab merge requests.
    /// </summary>
    public interface IMergeRequestClient : IBaseClient<MergeRequest, SelectMergeRequest>
    {
        /// <summary>
        /// Asynchronously retrieves a sequence of GitLab merge requests associated with a specific issue and options.
        /// </summary>
        /// <param name="idProjeto">The ID of the project associated with the merge requests.</param>
        /// <param name="idIssue">The ID of the issue linked to the merge requests.</param>
        /// <param name="requisicao">An action to configure the request for specific merge requests.</param>
        /// <returns>An asynchronous enumerable of responses containing lists of GitLab merge requests.</returns>
        IAsyncEnumerable<IResponse<IList<MergeRequest>>> GetAsync(int idProjeto, long idIssue, Action<SelectMergeRequest> requisicao);
    }
}
