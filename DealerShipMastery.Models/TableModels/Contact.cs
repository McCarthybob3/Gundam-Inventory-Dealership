﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerShipMastery.Models.TableModels
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public int? InventoryNumber { get; set; }
    }
}
