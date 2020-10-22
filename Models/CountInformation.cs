using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalmartInventory.Models
{
    public class CountInformation
    {

        public int CountInformationId { get; set; } //  primiry key
        public int ProductId { get; set; } // frogian key
        public int CountId { get; set; } // frogian key
        public int Onhand { get; set; }

        public Product Product { get; set; }
        public Count Count { get; set;}
          

    }
}
