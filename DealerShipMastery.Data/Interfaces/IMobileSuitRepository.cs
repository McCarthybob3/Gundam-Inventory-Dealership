using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealerShipMastery.Models.TableModels;
using DealerShipMastery.Models.QueryModels;

namespace DealerShipMastery.Data.Interfaces
{
    public interface IMobileSuitRepository
    {
        Mobile_Suit GetById(int MobileSuitId);
        void Insert(Mobile_Suit MobileSuit);
        void Update(Mobile_Suit MobileSuit);
        void Delete(int MobileSuitId);
        IEnumerable<Featured_Item> GetRecent();
        Detail_Result GetDetails(int MobileSuitId);
        IEnumerable<Mobile_Suit_Search_Result> GetByMake(string MakeName);
        IEnumerable<Mobile_Suit_Search_Result> GetByModel(string ModelName);
        IEnumerable<Mobile_Suit_Search_Result> GetByYear(int Year);
        IEnumerable<Mobile_Suit_Search_Result> GetByPrice(int Price);
        IEnumerable<Mobile_Suit_Search_Result> GetMassProduced();
        IEnumerable<Mobile_Suit_Search_Result> GetCustom();
        IEnumerable<Mobile_Suit_Search_Result> GetBroken();
    }
}
