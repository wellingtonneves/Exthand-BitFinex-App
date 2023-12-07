using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best.Buy.DTO
{
    public class RequestBase
    {
        public int Page { get; set; } = 1;
        public PageSize PageSize { get; set; } = PageSize.TWENTY;
        public string OrderColumn { get; set; } = null;
        public bool Ascending { get; set; } = true;
    }
}
