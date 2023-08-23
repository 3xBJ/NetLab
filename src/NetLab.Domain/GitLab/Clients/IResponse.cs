namespace NetLab.Infrastructure.Clients.Responses
{
    /// <summary>
    /// Represents a response interface containing information about a request's outcome.
    /// </summary>
    /// <typeparam name="TContent">The type of the content in the response.</typeparam>
    public interface IResponse<TContent>
    {
        /// <summary>
        /// Gets the content of the response.
        /// </summary>
        TContent? Content { get; }

        /// <summary>
        /// Gets a value indicating whether the request was successful.
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// Gets an error message associated with the response, if applicable.
        /// </summary>
        string? ErrorMessage { get; }
    }
}
