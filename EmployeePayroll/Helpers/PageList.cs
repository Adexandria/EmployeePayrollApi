using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Helpers
{
    public class PageList<T>:List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool Hasprevious => (CurrentPage > 1);
        public bool HasNext => (CurrentPage < TotalPage);
        public PageList(List<T> items, int count, int pageSize, int pagenumber) 
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pagenumber;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }
        public static PageList<T> Create(IQueryable<T> source,int pagenumber,int pagesize)
        {
            var count = source.Count();
            var items = source.Skip(pagesize * (pagenumber - 1)).Take(pagesize).ToList();
            return new PageList<T>(items, count, pagenumber, pagesize);
        }
    }
}
