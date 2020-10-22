using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalmartInventory.Models
{
    public class Product
    {
        public int ProductId { get; set; } // primary key

        public Department DepartmentId { get; set; } // forign key

        public String Name { get; set; }

        public int ShelfName { get; set; }

        public decimal RetailPrice { get; set; }

        public Department Department { get; set; }

        //this connect bw depart and product

        public List<CountInformation> CountInformations { get; set; }
    }
}
