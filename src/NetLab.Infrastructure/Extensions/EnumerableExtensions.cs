using System.ComponentModel;
using System.Reflection;

namespace NetLab.Infrastructure.Extensions
{
    /// <summary>
    /// Provides extension methods for working with enumerations.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Retrieves the description of an enumeration value.
        /// </summary>
        /// <param name="value">The enumeration value.</param>
        /// <returns>
        /// The description of the enumeration value, if available; otherwise, the string representation of the value.
        /// </returns>
        /// <remarks>
        /// This method retrieves the description associated with the provided enumeration value
        /// using the <see cref="DescriptionAttribute"/>. If no description is found, it returns
        /// the string representation of the enumeration value.
        /// </remarks>
        public static string GetDescription(this Enum value)
        {
            string fieldValue = value.ToString();
            FieldInfo? field = value.GetType().GetField(fieldValue);
            if (field == null) return fieldValue;

            Attribute? attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return (attribute is DescriptionAttribute descriptionAttribute) ? descriptionAttribute.Description : fieldValue;
        }
    }
}
