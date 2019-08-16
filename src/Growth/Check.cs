using Growth.Extensions;
using System;

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
                throw new ArgumentException($"{parameterName} can not be null or empty!", parameterName);
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
