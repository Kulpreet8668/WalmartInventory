using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalmartInventory.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }  // primary key

        public int ProductId { get; set; }

        public DateTime DateSelected { get; set; }

        public string EmployeeId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public Product Product { get; set; }


    }
}
