using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalmartInventory.Models
{
    public class Count
    {
        public int CountId { get; set; } // pk
        public int ManagerId { get; set; }
        public int userNumber { get; set; }
        public int departName { get; set; }
        public double countTotal { get; set; }

        //child reference to count detail

        public List<CountInformation> CountInformations { get; set; }



    }
}
