using NetLab.Domain.Parameters;

namespace NetLab.Domain.GitLab.Clients
{
    /// <summary>
    /// Provides a utility for creating instances of a specified type with custom configuration.
    /// </summary>
    /// <typeparam name="T">The type of object to create.</typeparam>
    public static class RequestCreator<T> where T: class , new()
    {
        /// <summary>
        /// Creates an instance of the specified type and applies custom configuration through the provided action.
        /// </summary>
        /// <param name="action">An action that configures the created instance.</param>
        /// <returns>
        /// The configured instance of the specified type.
        /// </returns>
        public static T Create(Action<T> action)
        {
            T instance = new();
            action?.Invoke(instance);
            return instance;
        }
    }
}
