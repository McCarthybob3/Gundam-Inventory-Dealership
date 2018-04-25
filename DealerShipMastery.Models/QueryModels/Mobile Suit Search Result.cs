using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerShipMastery.Models.QueryModels
{
    public class Mobile_Suit_Search_Result
    {

        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public int InventoryNumber { get; set; }
        public int Year { get; set; }
        public int MSRP { get; set; }
        public int SalePrice { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }  //used or new
        public string BodyStyle { get; set; }
        public string Weapon { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? ModelId { get; set; }
        public int? MakeId { get; set; }
        public string Color { get; set; }
        public string Interior { get; set; }
        public string Century { get; set; }
        public bool Featured { get; set; }

    }
}
