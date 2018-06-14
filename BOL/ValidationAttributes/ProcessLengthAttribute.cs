using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.ValidationAttributes
{
    /// <summary>
    /// This attribute help me to validate the length of the category process. The process length have to be betweeen 0, and 480.
    /// </summary>
    public class ProcessLengthAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ReservationAPPModel db = new ReservationAPPModel();
            if ((int)value < 0)
                return new ValidationResult("A folyamat hosszának nagyobbnak kell lennie 0-nál.");
            if ((int)value > 480)
                return new ValidationResult("A folyamat hossza nem lehet nagyobb 480 percnél.");
            return ValidationResult.Success;
        }
    }
}
