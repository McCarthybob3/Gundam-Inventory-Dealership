using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealerShipMastery.Models.TableModels;

namespace DealerShipMastery.Data.Interfaces
{
    public interface ITypeRepository
    {
        List<Models.TableModels.Type> GetAll();
    }
}
