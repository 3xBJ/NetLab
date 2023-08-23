using NetLab.GitLab.Util.Wrappers.Http.Interfaces;
using NetLab.Infrastructure.Wrappers.Http;
using NetLab.Infrastructure.Wrappers.Http.Interfaces;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace NetLab.Infrastructure.GitLab.Wrappers.Http
{
    /// <inheritdoc/>
    internal sealed class HttpClientWrapper : IHttpClient
    {
        private readonly HttpClient httpClient;
        private readonly string gitlabUri;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientWrapper"/> class with the provided <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/> instance to be wrapped.</param>
        /// <param name="gitlabUri">The GitLab's uri.</param>
        internal HttpClientWrapper(HttpClient httpClient, string gitlabUri)
        {
            if (string.IsNullOrEmpty(gitlabUri)) throw new ArgumentNullException(nameof(gitlabUri));
            this.gitlabUri = gitlabUri;
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(gitlabUri));
        }

        /// <inheritdoc/>
        public void AddRequestHeader(string name, string? value) => this.httpClient.DefaultRequestHeaders.Add(name, value);

        /// <inheritdoc/>
        public async Task<IHttpResponse<T>> GetAsync<T>(string url)
        {
            string urlGit = GetCompleteUrl(url);
            using HttpResponseMessage httpResponse = await this.httpClient.GetAsync(urlGit);
            string content = await httpResponse.Content.ReadAsStringAsync();

            T? objContent = default;
            string? error = null;

            if (!httpResponse.IsSuccessStatusCode)
            {
                error = content;
            }
            else
            {
                objContent = JsonSerializer.Deserialize<T>(content);
            }
            
            return new HttpResponse<T>()
            {
                IsSuccess = httpResponse.IsSuccessStatusCode,
                StatusCode = httpResponse.StatusCode,
                Content = objContent,
                ErrorMessage = error,
                Headers = httpResponse.Headers
            };
        }

        /// <inheritdoc/>
        public async Task<IHttpResponse<string>> PostAsync<T>(string url, T conteudo)
        {
            string urlGit = GetCompleteUrl(url);
            string json = JsonSerializer.Serialize(conteudo);

            using HttpContent httpContent = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
            using HttpResponseMessage httpResponse = await this.httpClient.PostAsync(urlGit, httpContent);

            string content = await httpResponse.Content.ReadAsStringAsync();
            return new HttpResponse<string>()
            {
                IsSuccess = httpResponse.IsSuccessStatusCode,
                StatusCode = httpResponse.StatusCode,
                Content = content,
                ErrorMessage = content,
                Headers = httpResponse.Headers
            }; 
        }

        private string GetCompleteUrl(string uri) => Path.Combine(gitlabUri, uri);
    }
}
