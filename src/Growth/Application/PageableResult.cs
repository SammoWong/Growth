using System.Collections.Generic;

namespace Growth.Application
{
    public class PageableResult
    {
        public int Total { get; set; }
    }

    public class PageableResult<T> : PageableResult
    {
        public PageableResult()
        {

        }

        public PageableResult(IEnumerable<T> items, int total)
        {
            Items = items;
            Total = total;
        }

        public IEnumerable<T> Items { get; set; }
    }
}
