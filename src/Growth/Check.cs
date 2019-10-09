using Growth.Extensions;
using System;
using System.Collections.Generic;

namespace Growth
{
    public static class Check
    {
        public static void NotNull<T>(T value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        public static void NotNullOrEmpty(string value, string parameterName)
        {
            if (value.IsNullOrEmpty())
            {
                throw new ArgumentException($"{parameterName} can not be null or empty", parameterName);
            }
        }

        public static void NotNullOrWhiteSpace(string value, string parameterName)
        {
            if (value.IsNullOrWhiteSpace())
            {
                throw new ArgumentException($"{parameterName} can not be null , empty or white space", parameterName);
            }
        }

        public static void NotNullOrEmpty<T>(ICollection<T> value, string parameterName)
        {
            if (value == null || value.Count <= 0)
            {
                throw new ArgumentException(parameterName + " can not be null or empty", parameterName);
            }
        }

        public static void GreaterThan<T>(T value, T target, string errorMsg, bool allowEqual = false) where T : IComparable<T>
        {
            var flag = allowEqual ? value.CompareTo(target) >= 0 : value.CompareTo(target) > 0;
            if (!flag)
                throw new ArgumentException(errorMsg);
        }
    }
}
