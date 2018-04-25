using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerShipMastery.Models.QueryModels
{
    public class MobileSuit
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public int InventoryNumber { get; set; }
        public int ModelID { get; set; }
        public int TypeID { get; set; }
        public int BodyStyleID { get; set; }
        public int Year { get; set; }
        public int WeaponID { get; set; }
        public int ColorID { get; set; }
        public int Interior { get; set; }
        public int MSRP { get; set; }
        public int SalePrice { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int MakeID { get; set; }
        public int CenturyID { get; set; }
        public bool Featured { get; set; }
    }
}
