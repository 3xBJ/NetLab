using System.Net.Http.Headers;

namespace NetLab.Infrastructure.Extensions
{
    /// <summary>
    /// Provides extension methods for working with HTTP-related classes.
    /// </summary>
    public static class Http
    {
        /// <summary>
        /// Retrieves the value of a specified header from the <see cref="HttpHeaders"/>.
        /// </summary>
        /// <typeparam name="T">The type to which the header value should be converted.</typeparam>
        /// <param name="header">The HTTP response headers.</param>
        /// <param name="chave">The header name to retrieve the value for.</param>
        /// <returns>
        /// The value of the specified header, converted to the specified type, if available; otherwise, the default value of the type.
        /// </returns>
        /// <remarks>
        /// This method attempts to retrieve the values of the specified header from the HTTP response headers.
        /// If the header values are found and not null, it converts the first value to the specified type.
        /// If the conversion is successful, the converted value is returned; otherwise, the default value of
        /// the specified type is returned.
        /// </remarks>
        public static T? GetValue<T>(this HttpHeaders? header, string chave)
        {
            if (header is not null &&
                header.TryGetValues(chave, out IEnumerable<string>? valores) &&
                valores is not null)
            {
                string? valor = valores.FirstOrDefault();
                return string.IsNullOrEmpty(valor) ? default : (T)Convert.ChangeType(valor, typeof(T));
            }

            return default;
        }
    }
}
