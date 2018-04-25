using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerShipMastery.Models.QueryModels
{
   public class Inventory
    {
       
            public int Year { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public int Count { get; set; }
            public int Value { get; set; }
        
    }
}
