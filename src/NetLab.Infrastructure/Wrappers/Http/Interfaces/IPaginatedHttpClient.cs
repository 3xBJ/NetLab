using NetLab.Infrastructure.GitLab.Wrappers.Http;

namespace NetLab.GitLab.Util.Wrappers.Http.Interfaces
{
    /// <summary>
    /// Represents an interface for an HTTP client capable of returning paginated responses.
    /// </summary>
    internal interface IPaginatedHttpClient : IHttpClient
    {
        /// <summary>
        /// Asynchronously retrieves a sequence of pages of content from the specified URL.
        /// </summary>
        /// <typeparam name="T">The type of the content in the response.</typeparam>
        /// <param name="url">The URL to request the pages from.</param>
        /// <returns>
        /// An asynchronous enumerable of responses containing lists of content.
        /// </returns>
        /// <remarks>
        /// This method fetches multiple pages of content from the provided URL using a paginated approach.
        /// It returns an asynchronous enumerable of responses, each containing a list of content.
        /// </remarks>
        IAsyncEnumerable<PaginatedResponse<IList<T>>> GetPagesAsync<T>(string url);
    }
}
