using CrossCutting.Filter;
using CrossCutting.Service;
using CrossCutting.Wrappers;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Helpers
{
    public static class PaginationHelper
    {
        public static PagedResponse<List<T>> CreatePagedReponse<T>(List<T> pagedData, IPaginationFilter validFilter, int totalRecords, IUriService uriService, string route)
        {
            validFilter = validFilter.GetValidValues(validFilter.PageNumber, validFilter.PageSize);

            var respose = new PagedResponse<List<T>>(pagedData, validFilter.PageNumber, validFilter.PageSize);
            var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            respose.NextPage =
                validFilter.PageNumber >= 1 && validFilter.PageNumber < roundedTotalPages
                ? uriService.GetPageUri(validFilter.GetValidValues(validFilter.PageNumber + 1, validFilter.PageSize), route)
                : null;
            respose.PreviousPage =
                validFilter.PageNumber - 1 >= 1 && validFilter.PageNumber <= roundedTotalPages
                ? uriService.GetPageUri(validFilter.GetValidValues(validFilter.PageNumber - 1, validFilter.PageSize), route)
                : null;
            respose.FirstPage = uriService.GetPageUri(validFilter.GetValidValues(1, validFilter.PageSize), route);
            respose.LastPage = uriService.GetPageUri(validFilter.GetValidValues(roundedTotalPages, validFilter.PageSize), route);
            respose.TotalPages = roundedTotalPages;
            respose.TotalRecords = totalRecords;

            return respose;
        }
    }
}