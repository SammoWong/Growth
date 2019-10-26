using Growth.Exceptions;
using System;
using Xunit;

namespace Growth.Tests.Exceptions
{
    public class ExceptionExtensions_Tests
    {
        [Fact]
        public void FormatException_Test()
        {
            Exception ex = new Exception("未知异常");
            Assert.True(ex != null);
            var message = ex.Format();
            Assert.Contains("未知异常", message);
        }

        [Fact]
        public void FormatKnownException_Test()
        {
            KnownException ex = new KnownException(1, "已知异常"); 
            Assert.True(ex != null);
            string msg = ex.Format();
            Assert.Equal(1, ex.Code);
            Assert.Contains("已知异常", msg);
        }
    }
}
