using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 日期格式化为字符串，格式"yyyy-MM-dd"
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToDateString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 日期格式化为字符串，格式"yyyy-MM-dd"
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToDateString(this DateTime? dateTime)
        {
            if (dateTime == null)
                return string.Empty;

            return ToDateString(dateTime.Value);
        }

        /// <summary>
        /// 日期格式化为字符串，格式"yyyy-MM-dd HH:mm:ss"
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToDateTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 日期格式化为字符串，格式"yyyy-MM-dd HH:mm:ss"
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToDateTimeString(this DateTime? dateTime)
        {
            if (dateTime == null)
                return string.Empty;

            return ToDateTimeString(dateTime.Value);
        }

        /// <summary>
        /// 日期格式化为字符串，格式"HH:mm:ss"
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("HH:mm:ss");
        }

        /// <summary>
        /// 日期格式化为字符串，格式"HH:mm:ss"
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToTimeString(this DateTime? dateTime)
        {
            if (dateTime == null)
                return string.Empty;

            return ToTimeString(dateTime.Value);
        }
    }
}
