using System.ComponentModel;

namespace Growth.Application
{
    public interface ISortableRequest
    {
        string SortField { get; set; }

        ListSortDirection SortDirection { get; set; }
    }
}
