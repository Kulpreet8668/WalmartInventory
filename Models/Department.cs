using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalmartInventory.Models
{
    public class Department
    {
        public int DepartmentId { get; set; } // primiry key
        [Required]

        public string Name { get; set; }

        public List<Product>Products { get; set; }

    }
}
