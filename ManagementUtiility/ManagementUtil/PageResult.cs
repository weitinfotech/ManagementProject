using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementUtil
{
    public class PageResult<T> where T : class
    {

        public PageResult() { }

        public PageResult(List<T> Data, int TotalItems, int PageNo, int PageSize)
        {
            this.Data = Data;
            this.TotalItems = TotalItems;
            this.PageNo = PageNo;
            this.PageSize = PageSize;
        }

        public List<T> Data { get; set; }
        public int TotalItems {get; set; }  
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }
}
