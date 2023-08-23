using NetLab.Infrastructure.Wrappers.Http.Interfaces;

namespace NetLab.GitLab.Util.Wrappers.Http.Interfaces
{
    /// <summary>
    /// Represents an HTTP client interface for making HTTP requests and receiving responses.
    /// </summary>
    internal interface IHttpClient
    {
        /// <summary>
        /// Adds a request header to be included in the HTTP request.
        /// </summary>
        /// <param name="name">The name of the header.</param>
        /// <param name="value">The value of the header.</param>
        void AddRequestHeader(string name, string? value);

        /// <summary>
        /// Sends an asynchronous GET request to the specified URL and returns the HTTP response.
        /// </summary>
        /// <typeparam name="T">The type of the expected response content.</typeparam>
        /// <param name="url">The URL to send the GET request to.</param>
        /// <returns>
        /// An asynchronous task that represents the HTTP response containing typed content.
        /// </returns>
        Task<IHttpResponse<T>> GetAsync<T>(string url);

        /// <summary>
        /// Sends an asynchronous POST request to the specified URL with the provided payload and returns the HTTP response.
        /// </summary>
        /// <typeparam name="T">The type of the payload to be sent in the POST request.</typeparam>
        /// <param name="url">The URL to send the POST request to.</param>
        /// <param name="payload">The payload to be included in the POST request.</param>
        /// <returns>
        /// An asynchronous task that represents the HTTP response containing string content.
        /// </returns>
        Task<IHttpResponse<string>> PostAsync<T>(string url, T payload);
    }
}