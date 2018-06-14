using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.ValidationAttributes
{
    /// <summary>
    /// This attribute help me to validate the nick name. The nick name have to be unique.
    /// </summary>
    public class UniqueNickNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ReservationAPPModel db = new ReservationAPPModel();
            if (db.USERS.Where(x => x.NickName == value.ToString()).Count() != 0)
                return new ValidationResult("A felhasználónévnek egyedinek kell lennie!");
            return ValidationResult.Success;
        }
    }
}
