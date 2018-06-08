using BOL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class UniqueCategoryNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ReservationDBEntities db = new ReservationDBEntities();
            if (db.CATEGORIES.Where(x => x.CategoryName == value.ToString()).Count() != 0)
                return new ValidationResult("A kategória névnek egyedinek kell lennie!");
            return ValidationResult.Success;
        }
    }

    public class CATEGORIES_Validation
    {
        [Required]
        [UniqueCategoryName]
        [Display(Name = "Kategóia név")]
        public string CategoryName { get; set; }

        [Required]
        [Display(Name = "Ár")]
        public Nullable<int> Price { get; set; }

        [Required]
        [Display(Name = "A folyamat hossza percben")]
        public Nullable<int> ProcessLengthInMunites { get; set; }
    }

    [MetadataType(typeof(CATEGORIES_Validation))]
    public partial class CATEGORIES
    {

    }
}
