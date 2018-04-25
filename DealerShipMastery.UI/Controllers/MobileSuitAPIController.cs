using DealerShipMastery.Data.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DealerShipMastery.Models.TableModels;
using DealerShipMastery.Models.QueryModels;

namespace DealerShipMastery.UI.Controllers
{
    public class MobileSuitAPIController : ApiController
    {
        [Route("api/contact/add/{InventoryNumber}")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddContact(Contact contact, int InventoryNumber)
        {
            var repo = new AccountRepositoryADO();

            //try
            //{
            repo.InsertContactSelect(contact, InventoryNumber);
            return Ok();
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
        }
        [Authorize]
        [Route("api/listings/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(decimal? minRate, decimal? maxRate, string make, string model, int typeid)
        {
            var repo = new MobileSuitRepositoryADO();

            try
            {
                var parameters = new MobileSuitSearchParameters()
                {
                    MinRate = minRate,
                    MaxRate = maxRate,
                    Make = make,
                    Model = model,
                    TypeId = typeid
                };

                var result = repo.Search(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Route("api/sales/search")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult Search(decimal? minRate, decimal? maxRate, string make, string model)
        //{
        //    var repo = new MobileSuitRepositoryADO();

        //    try
        //    {
        //        var parameters = new MobileSuitSearchParametersSales()
        //        {
        //            MinRate = minRate,
        //            MaxRate = maxRate,
        //            Make = make,
        //            Model = model,

        //        };

        //        var result = repo.SaleSearch(parameters);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


        [Route("api/contact/check/{userId}/{listingId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult CheckContact(string userId, int listingId)
        {
            var repo = new AccountRepositoryADO();

            try
            {
                var result = repo.IsContact(userId, listingId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [Route("api/contact/add/{userId}/{InventoryNumber}")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddContact(Contact contact,string userId, int InventoryNumber)
        {
            var repo = new AccountRepositoryADO();

            try
            {
               
                repo.InsertContactDirect(userId, InventoryNumber);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("api/contact/add")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddContact(Contact contact)
        {
            var repo = new AccountRepositoryADO();

            try
            {

                repo.InsertContact(contact);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/contact/add")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddContact(string Name, string Email, string Phone, string Message)
        {
            var repo = new AccountRepositoryADO();
            Contact contact = new Contact();
            contact.Email = Email;
            contact.Message = Message;
            contact.Name = Name;
            contact.Phone = Phone;
            try
            {
                repo.InsertContact(contact);
            return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/contact/remove/{userId}/{listingId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult RemoveContact(string userId, int listingId)
        {
            var repo = new AccountRepositoryADO();

            try
            {
                repo.RemoveContact(userId, listingId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
