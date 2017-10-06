using System;
using System.Collections.Generic;
using System.Linq;
using CoreLib.CrossCutting.Extensions;
using CoreLib.Entities;

namespace AltonikaShop.Application.Pagging
{
    public static class Paginator
    {
        public static PaggingResult<T> Page<T>(IEnumerable<T> all, PaggingOptions options) where T: NamedEntity
        {
            if (options.PageNumber <= 0)
                throw new ArgumentException(nameof(options.PageNumber));

            if (options.PageSize <= 0)
                throw new ArgumentException(nameof(options.PageSize));

            var list = options.SearchText.IsNullOrEmptyOrWhiteSpace() ?
                all.ToList() :
                all.Where(i => i.Name.ToLower().Contains(options.SearchText.ToLower())).ToList();

            var result = new PaggingResult<T> { TotalCount = list.Count };
            var startIndex = 0;

            if (options.PageNumber != 1)
                startIndex = options.PageSize * (options.PageNumber - 1);
            
            result.Items = startIndex + options.PageSize > list.Count ? 
                list.GetRange(startIndex, list.Count - startIndex).ToList() : 
                list.GetRange(startIndex, options.PageSize).ToList();
            
            result.CanNext = startIndex + options.PageSize < list.Count;
            result.CanPrev = options.PageNumber > 1;

            var pagesCount = result.TotalCount % options.PageSize == 0
                ? result.TotalCount / options.PageSize
                : result.TotalCount / options.PageSize + 1;

            result.PageNumbers = new List<int>();
            for (var i = 1; i <= pagesCount; i++)
                result.PageNumbers.Add(i);

            return result;
        }
    }
}
