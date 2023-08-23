using NetLab.Domain.GitLab.Clients;
using NetLab.GitLab.Util.Wrappers.Http.Interfaces;
using NetLab.Infrastructure.Clients.Responses;
using NetLab.Infrastructure.Parameters;

namespace NetLab.Infrastructure.Clients.REST
{
    /// <summary>
    /// Represents a client for working with milestones in a GitLab project.
    /// </summary>
    /// <typeparam name="TResponseContent">The type of the expected response content.</typeparam>
    /// <typeparam name="TRequestOptions">The type of the request parameters.</typeparam>
    internal abstract class BaseClient<TResponseContent, TRequestOptions> : IBaseClient<TResponseContent, TRequestOptions>
       where TResponseContent : class, new()
       where TRequestOptions : class, new()
    {
        protected IPaginatedHttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client used to perform paginated requests.</param>
        protected BaseClient(IPaginatedHttpClient httpClient) => this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

        /// <summary>
        /// Asynchronously retrieves a sequence of <typeparamref name="TResponseContent"/> from a project.
        /// </summary>
        /// <param name="projectId">The identifier of the project.</param>
        /// <param name="options">An action to customize the selection.</param>
        /// <returns>
        /// An asynchronous enumerable of responses containing lists of <typeparamref name="TResponseContent"/>.
        /// </returns>
        public async IAsyncEnumerable<IResponse<IList<TResponseContent>>> GetAsync(int projectId, Action<TRequestOptions> options)
        {
            string parameters = ParameterSerializer.Serialize(options);
            string uri = GetUrl(projectId, parameters);

            await foreach (IResponse<IList<TResponseContent>> response in this.httpClient.GetPagesAsync<TResponseContent>(uri))
            {
                yield return response;
            }
        }

        protected abstract string GetUrl(int projectId, string parameters);
    }
}
