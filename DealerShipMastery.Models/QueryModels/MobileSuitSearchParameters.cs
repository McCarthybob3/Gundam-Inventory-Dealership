using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerShipMastery.Models.QueryModels
{
    public class MobileSuitSearchParameters
    {
    
            public decimal? MinRate { get; set; }
            public decimal? MaxRate { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public int TypeId { get; set; }
        
    }
}
