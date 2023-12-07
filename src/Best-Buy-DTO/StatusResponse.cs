using System;
using System.Collections.Generic;

namespace Best.Buy.DTO
{
    public class StatusResponse<T>
    {
        public int StatusCode { get; set; }
        public PagedList<T> Data { get; set; }
        public object Errors { get; set; }
        public int Total { get; set; } = 0;
        public int CurrentPage { get; set; }
        public PageSize PageSize { get; set; }
        public int Pages { get; set; }
    }
}