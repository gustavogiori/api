using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IPaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public IPaginationFilter GetValidValues(int pageNumber, int pageSize);
    }
}
