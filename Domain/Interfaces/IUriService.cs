using Domain.Interfaces;
using System;

namespace Domain.Interfaces
{
    public interface IUriService
    {
        public Uri GetPageUri(IPaginationFilter filter, string route);
    }
}
