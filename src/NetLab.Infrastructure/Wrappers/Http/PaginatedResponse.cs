using NetLab.Infrastructure.Clients.Responses;
using NetLab.Infrastructure.Wrappers.Http;
using NetLab.Infrastructure.Wrappers.Http.Interfaces;

namespace NetLab.Infrastructure.GitLab.Wrappers.Http
{
    /// <inheritdoc/>
    internal class PaginatedResponse<T> : HttpResponse<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedResponse{T}"/> class.
        /// </summary>
        internal PaginatedResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedResponse{T}"/> class based on an existing <see cref="HttpResponse{T}"/>.
        /// </summary>
        /// <param name="httpResponse">The original HTTP response to base the paginated response on.</param>
        internal PaginatedResponse(IHttpResponse<T> httpResponse)
        {
            StatusCode = httpResponse.StatusCode;
            IsSuccess = httpResponse.IsSuccess;
            Content = httpResponse.Content;
            ErrorMessage = httpResponse.ErrorMessage;
        }

        /// <summary>
        /// Gets the page number of the next page in the paginated response.
        /// </summary>
        public int NextPage { get; init; }

        /// <summary>
        /// Get the total number of pages available in the paginated response.
        /// </summary>
        public int TotalPages { get; init; }
    }
}
