using NetLab.GitLab.Util.Wrappers.Http.Interfaces;
using NetLab.Infrastructure.Wrappers.Http.Interfaces;

namespace NetLab.Infrastructure.GitLab.Wrappers.Http
{
    /// <inheritdoc/>
    internal sealed class PaginatedHttpClient : IPaginatedHttpClient
    {
        private const string HEADER_TOTAL_PAGES = "X-Total-Pages";
        private const string HEADER_NEXT_PAGE = "X-Next-Page";

        private readonly IHttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedHttpClient"/> class.
        /// </summary>
        /// <param name="httpClient">The underlying HTTP client used to perform requests.</param>
        internal PaginatedHttpClient(IHttpClient httpClient) => this.httpClient = httpClient;

        /// <inheritdoc/>
        public void AddRequestHeader(string name, string? value) => this.httpClient.AddRequestHeader(name, value);

        /// <inheritdoc/>
        public Task<IHttpResponse<T>> GetAsync<T>(string url) => this.httpClient.GetAsync<T>(url);

        /// <inheritdoc/>
        public Task<IHttpResponse<string>> PostAsync<T>(string url, T conteudo) => this.httpClient.PostAsync(url, conteudo);

        /// <inheritdoc/>
        public async IAsyncEnumerable<PaginatedResponse<IList<T>>> GetPagesAsync<T>(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                yield return new PaginatedResponse<IList<T>>()
                {
                    ErrorMessage = "URL can't be null or empty"
                };

                yield break;
            }

            string urlPaginada = SetPageParam(url, 1);

            PaginatedResponse<IList<T>> info = await GetPageAsync<T>(urlPaginada);
            yield return info;

            if (info.TotalPages > 1)
            {
                IEnumerable<string>urls = Enumerable.Range(1, info.TotalPages -1)
                                                    .Select(i => SetPageParam(url, i));

                List<Task<PaginatedResponse<IList<T>>>> tasks = urls.Select(async url => await GetPageAsync<T>(url)).ToList();

                while (tasks.Count > 0)
                {
                    Task<PaginatedResponse<IList<T>>> completedTask = await Task.WhenAny(tasks);
                    tasks.Remove(completedTask);

                    yield return await completedTask;
                }
            }
        }

        /// <summary>
        /// Retrieves a single page of content from the specified URL and returns the paginated response.
        /// </summary>
        /// <typeparam name="T">The type of the content in the response.</typeparam>
        /// <param name="url">The URL to request the page from.</param>
        /// <returns>
        /// A task representing the asynchronous operation and containing the paginated response.
        /// </returns>

        private async Task<PaginatedResponse<IList<T>>> GetPageAsync<T>(string url)
        {
            IHttpResponse<IList<T>> resposta = await this.httpClient.GetAsync<IList<T>>(url);

            PaginatedResponse<IList<T>> info = AddPaginationData<T>(resposta);

            return info;
        }

        /// <summary>
        /// Adds pagination-related data to the paginated response based on the HTTP response headers.
        /// </summary>
        /// <typeparam name="T">The type of the content in the response.</typeparam>
        /// <param name="response">The HTTP response containing content and headers.</param>
        /// <returns>
        /// The paginated response with added pagination data.
        /// </returns>
        private static PaginatedResponse<IList<T>> AddPaginationData<T>(IHttpResponse<IList<T>> response)
        {
            int totalPaginas = response.GetHeader<int>(HEADER_TOTAL_PAGES);
            int proxPagina = response.GetHeader<int>(HEADER_NEXT_PAGE);

            return new PaginatedResponse<IList<T>>(response)
            {
                TotalPages = totalPaginas,
                NextPage = proxPagina
            };
        }

        /// <summary>
        /// Sets the page parameter in the URL for paginated requests.
        /// </summary>
        /// <param name="url">The original URL.</param>
        /// <param name="page">The page number to set in the URL.</param>
        /// <returns>
        /// The modified URL with the added page parameter.
        /// </returns>
        private static string SetPageParam(string url, int page)
        {
            char symbol = url.Contains('?') ? '&' : '?';
            return $"{url}{symbol}per_page=100&page={page}";
        }
    }
}
