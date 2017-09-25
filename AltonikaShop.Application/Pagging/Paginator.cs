using System;
using System.Collections.Generic;
using System.Linq;

namespace AltonikaShop.Application.Pagging
{
    public static class Paginator
    {
        public static PaggingResult<T> Page<T>(IEnumerable<T> all, PaggingOptions options)
        {
            if (options.PageNumber <= 0)
                throw new ArgumentException(nameof(options.PageNumber));

            if (options.PageSize <= 0)
                throw new ArgumentException(nameof(options.PageSize));

            var list = all.ToList();
            var result = new PaggingResult<T> { TotalCount = list.Count };
            var startIndex = 0;
            var endIndex = startIndex + options.PageSize;

            if (options.PageNumber != 1)
                startIndex = options.PageSize * (options.PageNumber - 1);

            if (startIndex + options.PageSize > list.Count)
            {
                result.Items = list.GetRange(startIndex, list.Count - startIndex).ToList();
            }
            else
            {
                result.Items = list.GetRange(startIndex, options.PageSize).ToList();
            }

            result.CanNext = endIndex < list.Count - 1;
            result.CanPrev = options.PageSize > 1;

            return result;
        }
    }
}
