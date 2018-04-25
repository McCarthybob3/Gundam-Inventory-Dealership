using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerShipMastery.Models.TableModels
{
    public class Model
    {
        public int ModelID { get; set; }
        public string Name { get; set; }
        public int? MakeId { get; set; }
        public string User { get; set; }
    }
}
