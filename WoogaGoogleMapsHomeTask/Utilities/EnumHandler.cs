using System.Reflection;
using System.Runtime.Serialization;

namespace WoogaGoogleMapsHomeTask.Utilities
{
    /// <summary>
    /// This class provides utility methods for handling enum types
    /// </summary>
    public class EnumHandler
    {
        /// <summary>
        /// This method parses a string value to the specified enum type by matching the string with the 
        /// <see cref="EnumMemberAttribute.Value"/> of the enum fields.
        /// </summary>
        /// <typeparam name="T">The enum type to parse to.</typeparam>
        /// <param name="value">The string value to parse.</param>
        /// <returns>The corresponding enum value.</returns>
        /// <exception cref="ArgumentException">Thrown when the specified value does not match any enum fields.</exception>
        public static T ParseEnum<T>(string value) where T : struct, Enum
        {
            var type = typeof(T);
            foreach (var field in type.GetFields())
            {
                var attribute = field.GetCustomAttribute<EnumMemberAttribute>();
                if (attribute != null && attribute.Value == value)
                {
                    return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException($"Requested value [ {value} ] was not found!", nameof(value));
        }
    }
}
