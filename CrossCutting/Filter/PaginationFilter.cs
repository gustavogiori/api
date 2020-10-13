using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Filter
{
    public class PaginationFilter : IPaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 5;
        }
        public IPaginationFilter GetValidValues(int pageNumber, int pageSize)
        {
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 5 : pageSize;
            return new PaginationFilter() { PageNumber = pageNumber, PageSize = pageSize };
        }
    }
}
