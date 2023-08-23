using NetLab.Infrastructure.Clients.Responses;

namespace NetLab.Domain.GitLab.Clients
{
    public interface IBaseClient<TResponseContent, TRequestOptions> where TResponseContent : class, new()
                                                                    where TRequestOptions : class, new()
    {
        /// <summary>
        /// Asynchronously retrieves a sequence of GitLab <typeparamref name="TResponseContent"/> based on the provided project ID and options.
        /// </summary>
        /// <param name="projectId">The ID of the project associated with the issues.</param>
        /// <param name="options">An action to configure the request for specific <typeparamref name="TResponseContent"/>.</param>
        /// <returns>
        /// An asynchronous enumerable of responses containing lists of GitLab <typeparamref name="TResponseContent"/>.
        /// </returns>
        IAsyncEnumerable<IResponse<IList<TResponseContent>>> GetAsync(int projectId, Action<TRequestOptions> options);
    }
}
