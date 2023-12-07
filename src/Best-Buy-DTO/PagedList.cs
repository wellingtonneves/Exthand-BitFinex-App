using Best.Buy.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Best.Buy.DTO
{
    public class PagedList<T> : List<T>
    {
        public PagedList() { }

        public PagedList(IEnumerable<T> items, int total, int currentPage, PageSize pageSize)
        {
            this.AddRange(items);
            Total = total;
            CurrentPage = currentPage;
            PageSize = pageSize;
            Pages = (int)Math.Ceiling(Total / (double)PageSize);
        }

        public int Total { get; set; }
        public int CurrentPage { get; set; }
        public PageSize PageSize { get; set; }
        public int Pages { get; set; }
    }

    public enum PageSize
    {
        NONE = 0,
        FIVE = 5,
        TEN = 10,
        TWENTY = 20,
        THIRTY = 30,
        FORTY = 40,
        FIFTY = 50,
        ONE_HUNDRED = 100
    }
}
