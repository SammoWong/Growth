using Newtonsoft.Json;

namespace Growth.Json
{
    public static class JsonExtensions
    {
        /// <summary>
        /// 对象转化为Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            return obj != null ? JsonConvert.SerializeObject(obj) : string.Empty;
        }

        /// <summary>
        /// 对象转化为Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static string ToJson(this object obj, JsonSerializerSettings settings)
        {
            return obj != null ? JsonConvert.SerializeObject(obj, settings) : string.Empty;
        }

        /// <summary>
        /// Json字符串转化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToObject<T>(this string value)
        {
            return value != null ? JsonConvert.DeserializeObject<T>(value) : default(T);
        }

        /// <summary>
        /// Json字符串转化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static T ToObject<T>(this string value, JsonSerializerSettings settings)
        {
            return value != null ? JsonConvert.DeserializeObject<T>(value, settings) : default(T);
        }
    }
}
