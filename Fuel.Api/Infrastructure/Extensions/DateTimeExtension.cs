namespace Fuel.Api.Infrastructure.Extensions
{
    using System;
    using System.Globalization;

    public static class DateTimeExtension
    {
        public static DateTime ToDateTime(this string s, string format, string culture)
        {
            DateTime.TryParseExact(s, format, CultureInfo.GetCultureInfo(culture), DateTimeStyles.None, out DateTime result);
            
            return result;
        }
    }
}
