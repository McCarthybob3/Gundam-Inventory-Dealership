using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerShipMastery.Models.QueryModels
{
    public class SalesReport
    {
        public string User { get; set; }
        public int TotalSales { get; set; }
        public int TotalVehicles { get; set; }
    }
}
