using DealerShipMastery.Models.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerShipMastery.Data.Interfaces
{
    interface ISpecialsRepository
    {
        IEnumerable<Special> GetAll();
    }
}
