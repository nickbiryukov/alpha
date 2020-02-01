using System.ComponentModel;
using System.Reflection;

namespace Alpha.Reservation.Extensions
{
    public static class GenericExtensions
    {
        public static string GetDescription<T>(this T source) =>
            source
                .GetType()
                .GetRuntimeField(source.ToString())
                .GetCustomAttribute<DescriptionAttribute>()
                ?.Description
            ?? source.ToString();
    }
}