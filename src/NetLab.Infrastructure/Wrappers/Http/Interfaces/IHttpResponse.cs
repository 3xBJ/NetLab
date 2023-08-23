using NetLab.Infrastructure.Clients.Responses;
using System.Net;

namespace NetLab.Infrastructure.Wrappers.Http.Interfaces
{
    /// <summary>
    /// Represents a response interface containing information about a request's outcome and related HTTP response.
    /// </summary>
    /// <typeparam name="TContent">The type of the content in the response.</typeparam>
    internal interface IHttpResponse<TContent> : IResponse<TContent>
    {
        /// <summary>
        /// Gets the HTTP status code of the response.
        /// </summary>
        HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Gets the HTTP response header with key.
        /// </summary>
        /// <param name="headerKey">The header's name</param>
        /// /// <typeparam name="THeaderValue">The type of the value in the header.</typeparam>
        THeaderValue? GetHeader<THeaderValue>(string headerKey);
    }
}
