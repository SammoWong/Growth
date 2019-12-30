using Growth.Extensions;
using System;
using System.Collections.Generic;
using System.IO;

namespace Growth
{
    public static class Check
    {
        public static void NotNull<T>(T value, string paramName)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"{paramName} can not be null", paramName);
            }
        }

        public static void NotNullOrEmpty(string value, string paramName)
        {
            if (value.IsNullOrEmpty())
            {
                throw new ArgumentException($"{paramName} can not be null or empty", paramName);
            }
        }

        public static void NotNullOrWhiteSpace(string value, string paramName)
        {
            if (value.IsNullOrWhiteSpace())
            {
                throw new ArgumentException($"{paramName} can not be null , empty or white space", paramName);
            }
        }

        public static void NotNullOrEmpty<T>(ICollection<T> value, string paramName)
        {
            if (value == null || value.Count <= 0)
            {
                throw new ArgumentException(paramName + " can not be null or empty", paramName);
            }
        }

        public static void GreaterThan<T>(T value, T target, string paramName, bool allowEqual = false) where T : IComparable<T>
        {
            var flag = allowEqual ? value.CompareTo(target) >= 0 : value.CompareTo(target) > 0;
            if (!flag)
                throw new ArgumentOutOfRangeException(paramName);
        }

        public static void LessThan<T>(T value, T target, string paramName, bool allowEqual = false) where T : IComparable<T>
        {
            var flag = allowEqual ? value.CompareTo(target) <= 0 : value.CompareTo(target) < 0;
            if (!flag)
                throw new ArgumentOutOfRangeException(paramName);
        }

        /// <summary>
        /// 检查指定文件夹路径是否存在，否则抛出异常
        /// </summary>
        /// <param name="path"></param>
        /// <param name="paramName"></param>
        public static void DirectoryExists(string path, string paramName)
        {
            NotNull(path, paramName);
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException(paramName);
        }

        /// <summary>
        /// 检查指定路径的文件是否存在，否则抛出异常
        /// </summary>
        /// <param name="path"></param>
        /// <param name="paramName"></param>
        public static void FileExists(string path, string paramName)
        {
            NotNull(path, paramName);
            if (!File.Exists(path))
                throw new FileNotFoundException(path);
        }
    }
}
