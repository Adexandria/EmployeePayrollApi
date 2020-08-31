using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Entities
{
    public class PageSizes
    {
        private const int maxPageSizes = 100;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 5;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > _pageSize) ? maxPageSizes : value;
        }
        public string Orderby { get; set; } = "Name";
        public string Fields { get; set; }
    }
}
