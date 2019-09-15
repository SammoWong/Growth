using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Growth.Application
{
    public class PageableRequest : IPageableRequest, ISortableRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortField { get; set; }
        public ListSortDirection SortDirection { get; set; }
    }
}
