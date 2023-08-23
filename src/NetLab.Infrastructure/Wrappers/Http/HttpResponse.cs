using NetLab.Infrastructure.Extensions;
using NetLab.Infrastructure.Wrappers.Http.Interfaces;
using System.Net;
using System.Net.Http.Headers;

namespace NetLab.Infrastructure.Wrappers.Http
{
    /// <inheritdoc/>
    internal class HttpResponse<T> : IHttpResponse<T>
    {
        /// <inheritdoc/>
        public T? Content { get; init; }

        /// <inheritdoc/>
        public HttpStatusCode StatusCode { get; init; }

        /// <inheritdoc/>
        public bool IsSuccess { get; init; }

        /// <inheritdoc/>
        public string? ErrorMessage { get; init; }

        public HttpHeaders? Headers { get; init; }

        /// <inheritdoc/>
        public THeaderValue? GetHeader<THeaderValue>(string headerKey) => Headers.GetValue<THeaderValue>(headerKey);
    }
}
