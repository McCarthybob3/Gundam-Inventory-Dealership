using DealerShipMastery.Models.TableModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DealerShipMastery.Models.QueryModels;
using System.Web.Mvc;

namespace DealerShipMastery.UI.Models
{
    public class AddMobileSuitViewModel
    {
        

        public Mobile_Suit MobileSuit { get; set; }
        public IEnumerable<SelectListItem> Makes { get; set; }
        public IEnumerable<SelectListItem> Models { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        public IEnumerable<SelectListItem> BodyStyles { get; set; }
        public IEnumerable<SelectListItem> Weapons { get; set; }
        public IEnumerable<SelectListItem> Colors { get; set; }
        public IEnumerable<SelectListItem> Centuries { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(MobileSuit.Name))
            {
                errors.Add(new ValidationResult("Item name is required."));
            }
           
            return errors;
        }
    }
}