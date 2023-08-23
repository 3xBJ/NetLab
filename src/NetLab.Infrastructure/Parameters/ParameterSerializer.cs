using NetLab.Domain.GitLab.Clients;
using NetLab.Domain.Parameters;
using NetLab.Infrastructure.Extensions;
using System.Collections;
using System.Reflection;
using System.Text;

namespace NetLab.Infrastructure.Parameters
{
    /// <summary>
    /// Provides utility methods for serializing objects into query string parameters.
    /// </summary>
    internal static class ParameterSerializer
    {
        /// <summary>
        /// Serializes an object with configuration using the provided action into a query string format.
        /// </summary>
        /// <typeparam name="T">The type of the object to be serialized.</typeparam>
        /// <param name="action">An action to configure the object before serialization.</param>
        /// <returns>
        /// A query string containing serialized parameter-value pairs.
        /// </returns>
        internal static string Serialize<T>(Action<T> action) where T : class, new()
        {
            T t = RequestCreator<T>.Create(action);
            return Serialize(t);
        }

        /// <summary>
        /// Serializes the provided object into a query string format, considering properties marked with <see cref="ParameterAttribute"/>.
        /// </summary>
        /// <typeparam name="T">The type of the object to be serialized.</typeparam>
        /// <param name="obj">The object to be serialized.</param>
        /// <returns>
        /// A query string containing serialized parameter-value pairs.
        /// </returns>
        internal static string Serialize<T>(T obj)
        {
            if (obj is null) return string.Empty;

            StringBuilder sb = new();
            foreach (PropertyInfo pi in obj.GetType().GetProperties())
            {
                Attribute? attribute = Attribute.GetCustomAttribute(pi, typeof(ParameterAttribute));
                if (attribute is not ParameterAttribute parameter || 
                    string.IsNullOrEmpty(parameter.Name))
                {
                    continue;
                }

                string? valor = GetPropertyValue(obj, pi);

                if (!string.IsNullOrEmpty(valor))
                {
                    _ = sb.Length == 0 ? sb.Append('?') : sb.Append('&');

                    sb.Append(parameter.Name)
                      .Append('=')
                      .Append(valor);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Retrieves the value of a property from the provided object and handles various value types.
        /// </summary>
        /// <typeparam name="T">The type of the object containing the property.</typeparam>
        /// <param name="obj">The object from which to retrieve the property value.</param>
        /// <param name="propertyInfo">The property information for the property to retrieve.</param>
        /// <returns>
        /// The serialized value of the property, handling different value types.
        /// </returns>
        private static string? GetPropertyValue<T>(T obj, PropertyInfo porpertyInfo)
        {
            object? propertyValue = porpertyInfo.GetValue(obj);
    
            if (propertyValue is string stringValue)
            {
                return stringValue;
            }
            else if (propertyValue is IEnumerable enumerableValue)
            {
                return ConcatValues(enumerableValue);
            }
            else if (propertyValue is Enum enumValue)
            {
                return enumValue.GetDescription();
            }

            return propertyValue?.ToString();
        }

        /// <summary>
        /// Concatenates values from an enumerable into a comma-separated string.
        /// </summary>
        /// <param name="enumerable">The enumerable containing values to concatenate.</param>
        /// <returns>A comma-separated string of concatenated values.</returns>
        private static string ConcatValues(IEnumerable enumerable)
        {
            List<string> values = new();

            foreach (var element in enumerable)
            {
                if (element is not string && element is IEnumerable)
                {
                    throw new NotSupportedException("Enumerable<IEnumerable> not supported");
                }

                if (element is string stringValue)
                {
                    values.Add(stringValue);
                }
                else
                {
                    values.Add(element.ToString()!);
                }
            }

            return string.Join(",", values);
        }
    }
}
