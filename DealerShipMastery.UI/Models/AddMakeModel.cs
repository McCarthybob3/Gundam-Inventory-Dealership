using DealerShipMastery.Models.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerShipMastery.UI.Models
{
    public class AddMakeModel
    {
       public IEnumerable<Make> Makes { get; set; }
       public string MakeName { get; set; }

    }
}