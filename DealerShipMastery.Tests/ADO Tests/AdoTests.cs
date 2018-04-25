using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DealerShipMastery.Data.ADO;
using DealerShipMastery.Models.TableModels;
using System.Data.SqlClient;
using System.Configuration;
using DealerShipMastery.Models.QueryModels;

namespace DealerShipMastery.Tests.ADO_Tests
{
    [TestFixture]
    public class AdoTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            } 
        }

        [Test]
        public void CanLoadStates()
        {
            var repo = new StateRepositoryADO();

            var states = repo.GetAll();

            Assert.AreEqual(3, states.Count);
            Assert.AreEqual("KY", states[0].StateID);
            Assert.AreEqual("Kentucky", states[0].Name);
        }

        [Test]
        public void CanLoadTypes()
        {
            var repo = new TypeRepositoryADO();

            var Type = repo.GetAll();

            Assert.AreEqual(3, Type.Count);
            Assert.AreEqual(1, Type[0].TypeID);
            Assert.AreEqual("Mass Produced", Type[0].Name);
        }


        [Test]
        public void CanLoadMobileSuit()
        {
            var repo = new MobileSuitRepositoryADO();

            var MobileSuit = repo.GetById(1);

            Assert.AreEqual("Zaku II", MobileSuit.Name.ToString());
      
        }


        [Test]
        public void FailLoadMobileSuit()
        {
            var repo = new MobileSuitRepositoryADO();

            var MobileSuit = repo.GetById(1);

            Assert.IsNull(MobileSuit);

        }



        [Test]
        public void CanInsertMobileSuit()
        {
            Mobile_Suit MobileSuit = new Mobile_Suit();
            var repo = new MobileSuitRepositoryADO();

            MobileSuit.UserID = "11111111-1111-1111-1111-111111111111";
            MobileSuit.BodyStyleID = 1;
            MobileSuit.ColorID = 2;
            MobileSuit.Interior = 2;
            MobileSuit.Description = "Custom Red Zaku II, Customized for peak performance for commanders of the Zeon army. 3x Faster than the base model with an added shield attatchment. ";
            MobileSuit.MakeModelID = 2;
            MobileSuit.MSRP = 120000;
            MobileSuit.SalePrice = 100000;
            MobileSuit.SerialNumber = "0123456789";
            MobileSuit.TypeID = 2;
            MobileSuit.WeaponID = 1;
            MobileSuit.Year = 0079;
            MobileSuit.Name = "Zaku II Commander Type";
            MobileSuit.Image = "Placeholder.Jpeg";
            MobileSuit.CenturyID = 1;
            MobileSuit.Featured = true;


            repo.Insert(MobileSuit);

            Assert.AreEqual(7, MobileSuit.InventoryNumber);

        }


        [Test]
        public void CanUpdateMobileSuit()
        {
            Mobile_Suit MobileSuit = new Mobile_Suit();
            var repo = new MobileSuitRepositoryADO();


            MobileSuit.BodyStyleID = 1;
            MobileSuit.ColorID = 2;
            MobileSuit.Interior = 2;
            MobileSuit.Description = "Custom Red Zaku II, Customized for peak performance for commanders of the Zeon army. 3x Faster than the base model with an added shield attatchment. ";
            MobileSuit.MakeModelID = 2;
            MobileSuit.MSRP = 120000;
            MobileSuit.SalePrice = 100000;
            MobileSuit.SerialNumber = "0123456789";
            MobileSuit.TypeID = 2;
            MobileSuit.WeaponID = 1;
            MobileSuit.Year = 0079;
            MobileSuit.Name = "Zaku II Commander Type";
            MobileSuit.Image = "Placeholder.Jpeg";
            MobileSuit.CenturyID =1;
            MobileSuit.UserID = "11111111-1111-1111-1111-111111111111";
            MobileSuit.Featured = true;

            repo.Insert(MobileSuit);

            MobileSuit.ColorID = 3;
            MobileSuit.Name = "Zaku Reconnaissance Type";
            MobileSuit.TypeID = 1;
            MobileSuit.Featured = false;

            repo.Update(MobileSuit);


            var updatedMobileSuit = repo.GetById(7);
            Assert.AreEqual("Zaku Reconnaissance Type", updatedMobileSuit.Name);


        }

        [Test]
        public void CanDeleteMobileSuit()
        {
            Mobile_Suit MobileSuit = new Mobile_Suit();
            var repo = new MobileSuitRepositoryADO();

           
            MobileSuit.BodyStyleID = 1;
            MobileSuit.ColorID = 2;
            MobileSuit.Interior = 2;
            MobileSuit.Description = "Custom Red Zaku II, Customized for peak performance for commanders of the Zeon army. 3x Faster than the base model with an added shield attatchment. ";
            MobileSuit.MakeModelID = 2;
            MobileSuit.MSRP = 120000;
            MobileSuit.SalePrice = 100000;
            MobileSuit.SerialNumber = "0123456789";
            MobileSuit.TypeID = 2;
            MobileSuit.WeaponID = 1;
            MobileSuit.Year = 0079;
            MobileSuit.CenturyID = 1; 
            MobileSuit.Name = "Zaku II Commander Type";
            MobileSuit.Image = "Placeholder.Jpeg";
            MobileSuit.UserID = "11111111-1111-1111-1111-111111111111";
            MobileSuit.Featured = true;

            repo.Insert(MobileSuit);

           


            var loadMobileSuit = repo.GetById(2);
            Assert.IsNotNull(loadMobileSuit.Name);

            repo.Delete(6);
            loadMobileSuit = repo.GetById(6);
            Assert.IsNull(loadMobileSuit.Name);


        }

        [Test]
        public void CanLoadRecentGundam()
        {
            var repo = new MobileSuitRepositoryADO();
            List<Featured_Item> gundams = repo.GetRecent().ToList();

            Assert.AreEqual(6, gundams.Count());
            Assert.AreEqual(1, gundams[0].InventoryNumber);

        }

        [Test]
        public void CanLoadCustom()
        {
            var repo = new MobileSuitRepositoryADO();
            List<Mobile_Suit_Search_Result> gundams = repo.GetCustom().ToList();

            Assert.AreEqual(2, gundams.Count());
            Assert.AreEqual(2, gundams[0].InventoryNumber);

        }


        [Test]
        public void CanLoadBroken()
        {
            var repo = new MobileSuitRepositoryADO();
            List<Mobile_Suit_Search_Result> gundams = repo.GetBroken().ToList();

            Assert.AreEqual(0, gundams.Count());
      

        }

        [Test]
        public void CanLoadSpecial()
        {
            var repo = new SpecialsRepositoryADO();
            List<Special> specials = repo.GetAll().ToList();

            Assert.AreEqual(2, specials.Count());


        }

        [Test]
        public void CanLoadMassProduced()
        {
            var repo = new MobileSuitRepositoryADO();
            List<Mobile_Suit_Search_Result> gundams = repo.GetMassProduced().ToList();

            Assert.AreEqual(4, gundams.Count());
            Assert.AreEqual(1, gundams[0].InventoryNumber);

        }

        [Test]
        public void CanLoadGundamDetails()
        {
            var repo = new MobileSuitRepositoryADO();
            Detail_Result gundams = repo.GetDetails(2);

            Assert.AreEqual("UC", gundams.Century);
            Assert.AreEqual(79, gundams.Year);
            Assert.AreEqual("Custom", gundams.Type);
            Assert.AreEqual("Red", gundams.Interior);
            Assert.AreEqual("Red", gundams.Color);
            Assert.AreEqual("Zaku II Char Custom", gundams.Name);

        }


        [Test]
        public void CanLoadContacts()
        {
            var repo = new AccountRepositoryADO();

            var Type = repo.GetContact(1);

            Assert.AreEqual("Bill", Type.Name);
         
        }
        [Test]
        public void CanInsertContacts()
        {
            var repo = new AccountRepositoryADO();
            var contact = new Contact();
            contact.Name = "Test";
            contact.Phone = "1234567890";
            contact.Message = "Testing";
            contact.Email = "Test";
             repo.InsertContact(contact);

            var Type = repo.GetContact(3);

            Assert.AreEqual("Test", Type.Name);
            Assert.AreEqual("Test", Type.Email);
            Assert.AreEqual("Testing", Type.Message);
            Assert.AreEqual("1234567890", Type.Phone);

        }

        [Test]
        public void CanDeleteContact()
        {
            var repo = new AccountRepositoryADO();
            var contact = new Contact();
            contact.Name = "Test";
            contact.Phone = "1234567890";
            contact.Message = "Testing";
            contact.Email = "Test";
            repo.InsertContact(contact);



            var load = repo.GetContact(3);
            Assert.IsNotNull(load.Name);

            repo.DeleteContact(3);
            load = repo.GetContact(3);
            Assert.IsNull(load.Name);


        }

        [Test]
        public void CanSelectByYear()
        {
            var repo = new MobileSuitRepositoryADO();
            int year = 79;
           var list = repo.GetByYear(year);

            Assert.AreEqual(6, list.Count());
        }

        [Test]
        public void CanSelectByPrice()
        {
            var repo = new MobileSuitRepositoryADO();
            int price = 1000000;
            var list = repo.GetByPrice(price);

            Assert.AreEqual(3, list.Count());
        }

        [Test]
        public void CanSelectByMake()
        {
            var repo = new MobileSuitRepositoryADO();
            string Make = "MS";
            var list = repo.GetByMake(Make);

            Assert.AreEqual(3, list.Count());
        }

        [Test]
        public void CanSelectByModel()
        {
            var repo = new MobileSuitRepositoryADO();
            string Model = "06";
            var list = repo.GetByModel(Model);

            Assert.AreEqual(2, list.Count());
        }


    }
}
