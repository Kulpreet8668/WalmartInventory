using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalmartInventory.Models
{
    public class Product
    {
        public int ProductId { get; set; } // primary key

        public int DepartmentId { get; set; } // forign key

        public String Name { get; set; }
        [Required]
        public String ShelfName { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:c}")]

        public double RetailPrice { get; set; }
        
        public Department Department { get; set; }

        //this connect bw depart and product

        public List<CountInformation> CountInformations { get; set; }

        public List<ShoppingCart> ShoppingCarts { get; set; }


    }
}
