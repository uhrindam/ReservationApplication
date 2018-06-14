using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.ValidationAttributes
{
    /// <summary>
    /// This attribute help me to validate the emailaddress. The email address have to be unique.
    /// </summary>
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                ReservationAPPModel db = new ReservationAPPModel();
                if (db.USERS.Where(x => x.EmailAddress == value.ToString()).Count() != 0)
                    return new ValidationResult("Egy emailcímmel csak egyszer regisztrálhatsz!");
                return ValidationResult.Success;
            }
            return null;
        }
    }
}
