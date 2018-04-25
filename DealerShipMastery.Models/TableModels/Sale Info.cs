using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerShipMastery.Models.TableModels
{
    public class Sale_Info
    {
        public int PurchaseID { get; set; }
        public int InventoryNumber { get; set; }
        public string SerialNumber { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public int StateID { get; set; }
        public int TypeID { get; set; }
        public int Price { get; set; }


    }
}
