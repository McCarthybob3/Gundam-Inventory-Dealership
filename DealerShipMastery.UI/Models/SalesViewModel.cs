using DealerShipMastery.Models.QueryModels;
using DealerShipMastery.Models.TableModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace DealerShipMastery.UI.Models
{
    public class SalesViewModel
    {
        public IEnumerable<SelectListItem> States { get; set; }
        public IEnumerable<SelectListItem> Purchase { get; set; }

        public Detail_Result MobileSuit { get; set; }
        public Sale_Info Sale { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrEmpty(MobileSuit.Name))
            {
                errors.Add(new ValidationResult("Nickname is required"));
            }
            return errors;
        }
    }
}