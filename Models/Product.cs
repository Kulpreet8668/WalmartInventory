using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalmartInventory.Models
{
    public class Product
    {
        public int ProductId { get; set; } // primary key

        public int DepartmentId { get; set; } // forign key

        public String Name { get; set; }

        public String ShelfName { get; set; }

        public double RetailPrice { get; set; }
        
        public Department Department { get; set; }

        //this connect bw depart and product

        public List<CountInformation> CountInformations { get; set; }
    }
}
