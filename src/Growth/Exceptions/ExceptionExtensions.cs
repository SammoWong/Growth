using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Exceptions
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// 格式化异常消息
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="isHideStackTrace"></param>
        /// <returns></returns>
        public static string Format(this Exception ex, bool isHideStackTrace = false)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            string appString = string.Empty;
            while (ex != null)
            {
                if (count > 0)
                {
                    appString += "  ";
                }
                if (ex is KnownException knownEx)
                {
                    sb.AppendLine(string.Format("{0}异常Code：{1}", appString, knownEx.Code));
                }
                sb.AppendLine(string.Format("{0}异常消息：{1}", appString, ex.Message));
                sb.AppendLine(string.Format("{0}异常类型：{1}", appString, ex.GetType().Name));
                sb.AppendLine(string.Format("{0}异常方法：{1}", appString, ex.TargetSite?.Name));
                sb.AppendLine(string.Format("{0}异常源：{1}", appString, ex.Source));
                if (!isHideStackTrace && ex.StackTrace != null)
                {
                    sb.AppendLine(string.Format("{0}异常堆栈：{1}", appString, ex.StackTrace));
                }
                if (ex.InnerException != null)
                {
                    sb.AppendLine(string.Format("{0}内部异常：", appString));
                    count++;
                }
                ex = ex.InnerException;
            }
            return sb.ToString();
        }
    }
}
