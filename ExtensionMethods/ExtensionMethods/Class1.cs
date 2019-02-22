using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class ExtensionMethod
    {
        /// <summary>
        /// Parse Date Time.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        public static DateTime ParseDateTime(string dateTime, int locale)
        {
            var defaultDateTime = new DateTime();
            try
            {
                if (string.IsNullOrEmpty(dateTime)) return defaultDateTime;

                DateTime parsedDateTime;

                if (locale != 0)
                {
                    if (DateTime.TryParse(dateTime, new CultureInfo(locale, false).DateTimeFormat, DateTimeStyles.None, out parsedDateTime)) return parsedDateTime;
                }

                if (DateTime.TryParse(dateTime, out parsedDateTime)) return parsedDateTime;

                return defaultDateTime;
            }
            catch
            {
                //
            }

            return defaultDateTime;
        }

        /// <summary>
        /// To Boolean.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="handleYesNo"></param>
        /// <returns></returns>
        public static bool ToBoolean(this string value, bool handleYesNo = true)
        {
            if (string.IsNullOrEmpty(value)) return false;

            if (value.Equals("1")) return true;

            if (value.Equals("0")) return false;

            if (handleYesNo)
            {
                if (value.Equals("yes", StringComparison.InvariantCultureIgnoreCase)) return true;

                if (value.Equals("no", StringComparison.InvariantCultureIgnoreCase)) return false;
            }

            return Convert.ToBoolean(value);
        }


        /// <summary>
        /// To the boolean.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool ToBoolean(string value)
        {
            return value.ToBoolean();
        }

        /// <summary>
        /// Convert Bool to string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertboolToString(bool value)
        {
            return value.ToString(CultureInfo.InvariantCulture).ToUpperInvariant();
        }

        /// <summary>
        /// Equal Invariant.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="valueToCompare"></param>
        /// <param name="stringComparision"></param>
        /// <returns></returns>
        public static bool EqualInvariant(this string input, string valueToCompare, StringComparison? stringComparision = null)
        {
            var strComprision = stringComparision ?? StringComparison.InvariantCultureIgnoreCase;
            return input != null && valueToCompare != null && input.Equals(valueToCompare, strComprision);
        }

        /// <summary>
        /// Convert to inteer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ConvertToInt32(this string value)
        {
            return string.IsNullOrEmpty(value) ? 0 : Convert.ToInt32(value);
        }

        /// <summary>
        /// Parse Guid.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid ParseGuid(string value)
        {
            Guid result;
            try
            {
                if (!Guid.TryParse(value, out result))
                {
                    result = Guid.Empty;
                }
            }
            catch
            {
                result = Guid.Empty;
            }
            return result;
        }

    }
}
