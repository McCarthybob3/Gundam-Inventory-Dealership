using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealerShipMastery.Models.QueryModels;
using DealerShipMastery.Models.TableModels;

namespace DealerShipMastery.Data.Interfaces
{
   public interface IAccountRepository
    {
        Contact GetContact(int ContactID);
       //   IEnumerable<ContactRequest> GetAllContacts(int ContactID);
        void InsertContact(Contact contact);
        void InsertContactSelect(Contact contact, int InventoryNumber);
        void DeleteContact(int ContactID);
    }
}
