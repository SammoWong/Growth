using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Growth.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// 字符串是否null或空字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// 字符串是否是null，空字符串，或空白字符
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }


        /// <summary>
        /// 字符串是否匹配指定的正则表达式
        /// </summary>
        /// <param name="value">需匹配的字符串</param>
        /// <param name="pattern">要匹配的正则表达式</param>
        /// <returns>是否匹配成功</returns>
        public static bool IsMatch(this string value, string pattern)
        {
            if (value == null)
                return false;

            return Regex.IsMatch(value, pattern);
        }

        /// <summary>
        /// 是否电子邮件
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmail(this string value)
        {
            var pattern = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
            return value.IsMatch(pattern);
        }

        /// <summary>
        /// 是否IP地址
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsIpAddress(this string value)
        {
            var pattern = @"^((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))$";
            return value.IsMatch(pattern);
        }

        /// <summary>
        /// 是否手机号
        /// </summary>
        /// <param name="value">手机号</param>
        /// <param name="isStrict">是否按严格格式验证</param>
        /// <returns></returns>
        public static bool IsMobileNumber(this string value, bool isStrict = false)
        {
            string pattern = isStrict ? @"^[1][3-8]\d{9}$" : @"^[1]\d{10}$";
            return value.IsMatch(pattern);
        }

        /// <summary>
        /// 以指定字符串为分隔符将指定字符串分隔成数组
        /// </summary>
        /// <param name="value">要分割的字符串</param>
        /// <param name="strSplit">作为分隔符的字符串</param>
        /// <param name="removeEmptyEntries">是否移除数据中元素为空字符串的项</param>
        /// <returns></returns>
        public static string[] Split(this string value, string strSplit, bool removeEmptyEntries = false)
        {
            return value.Split(new[] { strSplit }, removeEmptyEntries ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
        }

        /// <summary>
        /// 给Url添加查询参数
        /// </summary>
        /// <param name="url">Url</param>
        /// <param name="queries">要添加的参数如id=1</param>
        /// <returns></returns>
        public static string AddUrlQuery(this string url, params string[] queries)
        {
            foreach (var query in queries)
            {
                if (!url.Contains("?"))
                    url += "?";
                else if (!url.EndsWith("&"))
                    url += "&";
                url += query;
            }
            return url;
        }

        /// <summary>
        /// 获取URL中指定参数的值，不存在返回空字符串
        /// </summary>
        /// <param name="url"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetUrlQuery(this string url, string key)
        {
            Uri uri = new Uri(url);
            var query = uri.Query;
            if (query.IsNullOrEmpty())
                return string.Empty;

            query = query.TrimStart('?');
            var dict = (from q in query.Split('&')
                        let strs = q.Split("=")
                        select new KeyValuePair<string, string>(strs[0], strs[1]))
                       .ToDictionary(m => m.Key, m => m.Value);

            if (dict.ContainsKey(key))
                return dict[key];

            return string.Empty;
        }

        /// <summary>
        /// 将字符串进行UrlDecode编码
        /// </summary>
        /// <param name="value">要编码的字符串</param>
        /// <returns></returns>
        public static string ToUrlEncode(this string value)
        {
            return HttpUtility.UrlEncode(value);
        }

        /// <summary>
        /// 将字符串进行UrlDecode解码
        /// </summary>
        /// <param name="value">要解码的字符串</param>
        /// <returns></returns>
        public static string ToUrlDecode(this string value)
        {
            return HttpUtility.UrlDecode(value);
        }

        /// <summary>
        /// 将字符串进行HtmlEncode编码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToHtmlEncode(this string value)
        {
            return HttpUtility.HtmlEncode(value);
        }

        /// <summary>
        /// 将字符串进行HtmlDecode解码
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToHtmlDecode(this string value)
        {
            return HttpUtility.HtmlDecode(value);
        }

        /// <summary>
        /// 移除末尾字符串
        /// </summary>
        /// <param name="value">原字符串</param>
        /// <param name="removeValue">要移除的字符串</param>
        /// <returns></returns>
        public static string RemoveEnd(this string value, string removeValue)
        {
            if (value.IsNullOrWhiteSpace())
                return string.Empty;

            if (value.ToLower().EndsWith(removeValue.ToLower()))
                return value.Remove(value.Length - removeValue.Length, removeValue.Length);

            return value;
        }

        /// <summary>
        /// 移除特定字符
        /// </summary>
        /// <param name="value"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static string RemoveWhere(this string value, Func<char, bool> predicate)
        {
            return new string(value.ToCharArray().Where(x => !predicate(x)).ToArray());
        }

        /// <summary>
        /// 反转字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Reverse(this string value)
        {
            if (value.IsNullOrWhiteSpace())
                return value;

            var array = value.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}
