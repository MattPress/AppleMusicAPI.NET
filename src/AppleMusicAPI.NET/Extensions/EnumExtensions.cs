using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;

namespace AppleMusicAPI.NET.Extensions
{
    public static class EnumExtensions
    {
        public static string GetValue<T>(this T @enum) where T : IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            var enumValue = @enum.ToString(CultureInfo.InvariantCulture);
            var fieldInfo = @enum.GetType().GetField(enumValue);
            var attribute = (EnumMemberAttribute)fieldInfo?.GetCustomAttribute(typeof(EnumMemberAttribute));
            return attribute?.Value ?? enumValue;
        }
    }
}
