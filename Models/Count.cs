using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalmartInventory.Models
{
    public class Count
    {
        public int CountId { get; set; } // pk
        public double ManagerId { get; set; }
      
        public double countTotal { get; set; }
        public double userNumber { get; set; }
        public String departName { get; set; }

      

        public List<CountInformation> CountInformations { get; set; }



    }
}
