using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Pagination
    {
        private int pageSize;
        public int PageSize
        {
            get
            {
                return 50;
            }
            //set
            //{
            //    if (Convert.ToString(value) == "")
            //        pageSize = 2;  
            //}
        }
        public int Take { get; set; }
        public long Skip { get; set; }
        public int CurrentPageIndex { get; set; }
        public string SearchText { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }
}
