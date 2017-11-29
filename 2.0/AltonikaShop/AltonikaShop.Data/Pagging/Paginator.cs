using System;
using System.Collections.Generic;
using System.Linq;
using CoreLib.CrossCutting.Extensions;
using CoreLib.Entities;

namespace AltonikaShop.Data.Pagging
{
    public static class Paginator
    {
        public static PaggingResult<T> Page<T>(IEnumerable<T> all, PaggingOptions options) where T : NamedEntity
        {
            if (options.PageNumber <= 0)
                throw new ArgumentException(nameof(options.PageNumber));

            if (options.PageSize <= 0)
                throw new ArgumentException(nameof(options.PageSize));

            var list = options.SearchText.IsNullOrEmptyOrWhiteSpace()
                ? all.ToList()
                : all.Where(i => i.Name.ToLower().Contains(options.SearchText.ToLower())).ToList();

            var result = new PaggingResult<T>
            {
                Current =
                    options.PageSize * options.PageNumber <= list.Count
                        ? options.PageSize * options.PageNumber
                        : list.Count,
                Total = list.Count
            };

            var startIndex = 0;
            if (options.PageNumber != 1)
                startIndex = options.PageSize * (options.PageNumber - 1);

            result.Items = startIndex + options.PageSize > list.Count
                ? list.GetRange(startIndex, list.Count - startIndex).ToList()
                : list.GetRange(startIndex, options.PageSize).ToList();

            result.CanNext = startIndex + options.PageSize < list.Count;
            result.CanPrev = options.PageNumber > 1;

            var pagesCount = result.Total % options.PageSize == 0
                ? result.Total / options.PageSize
                : result.Total / options.PageSize + 1;

            result.PageNumbers = new List<int>();
            for (var i = 1; i <= pagesCount; i++)
                result.PageNumbers.Add(i);

            return result;
        }
    }
}
