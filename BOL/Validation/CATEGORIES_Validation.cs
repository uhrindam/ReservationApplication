using BOL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{

    public class ProcessLengthAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ReservationDBEntities db = new ReservationDBEntities();
            if ((int)value < 0)
                return new ValidationResult("A folyamat hosszának nagyobbnak kell lennie 0-nál.");
            if ((int)value > 480)
                return new ValidationResult("A folyamat hossza nem lehet nagyobb 480 percnél.");
            return ValidationResult.Success;
        }
    }

    public class CATEGORIES_Validation
    {
        [Required]
        [Display(Name = "Kategóia név")]
        public string CategoryName { get; set; }

        [Required]
        [Display(Name = "Ár")]
        public Nullable<int> Price { get; set; }

        [Required]
        [ProcessLengthAttribute]
        [Display(Name = "A folyamat hossza percben")]
        public Nullable<int> ProcessLengthInMunites { get; set; }
    }

    [MetadataType(typeof(CATEGORIES_Validation))]
    public partial class CATEGORIES
    {

    }
}
