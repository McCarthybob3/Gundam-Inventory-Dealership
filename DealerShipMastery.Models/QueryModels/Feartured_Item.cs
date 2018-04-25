using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerShipMastery.Models.QueryModels
{
    public class Featured_Item
    {
        public int InventoryNumber { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int SalePrice { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
    }
}
