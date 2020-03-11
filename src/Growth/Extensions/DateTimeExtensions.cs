using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Extensions
{
    public static class DateTimeExtensions
    {
        private static readonly DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);

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

        /// <summary>
        /// DateTime转Unix时间戳（秒）
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long ToUnixTimestamp(this DateTime dateTime)
        {
            dateTime = dateTime.AddHours(-8);
            return (long)(dateTime - origin).TotalSeconds;
        }

        /// <summary>
        /// Unix时间戳转DateTime（秒）
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this long timeStamp)
        {
            return origin.AddDays(timeStamp).AddHours(8);
        }
    }
}
