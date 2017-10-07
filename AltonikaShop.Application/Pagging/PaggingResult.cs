using System.Collections.Generic;

namespace AltonikaShop.Application.Pagging
{
    public class PaggingResult<T>
    {
        public List<T> Items { get; set; }
        
        public int Current { get; set; }

        public int Total { get; set; }

        public bool CanNext { get; set; }

        public bool CanPrev { get; set; }

        public List<int> PageNumbers;
    }
}
