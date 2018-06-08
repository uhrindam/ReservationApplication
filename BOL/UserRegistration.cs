using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace BOL
{
    public class UniqueEmailAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ReservationDBEntities db = new ReservationDBEntities();
            if (db.USERS.Where(x => x.EmailAddress == value.ToString()).Count() != 0)
                return new ValidationResult("Egy emailcímmel csak egyszer regisztrálhatsz!");
            return ValidationResult.Success;
        }
    }

    public class UniqueNickNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ReservationDBEntities db = new ReservationDBEntities();
            if (db.USERS.Where(x => x.NickName == value.ToString()).Count() != 0)
                return new ValidationResult("A felhasználónévnek egyedinek kell lennie!");
            return ValidationResult.Success;
        }
    }

    public class UserRegistration
    {
        [Display(Name = "Felhasználónév")]
        [UniqueEmail]
        [Required]
        public string NickName { get; set; }

        [Display(Name = "Teljes név")]
        [Required]
        public string FullName { get; set; }

        [Display(Name = "Emailcím")]
        [UniqueEmail]
        [Required]
        [EmailAddress(ErrorMessage = "Érvénytelen emailcím.")]
        public string EmailAddress { get; set; }

        [Display(Name = "Jelszó")]
        [Required]
        public string Passwd { get; set; }

        [Display(Name = "Megerősítő jelszó")]
        [Required]
        [Compare("Passwd", ErrorMessage = "A megerősítő jelszónak meg kell egyeznie a jelszóval.")]
        public string PasswdConfirm { get; set; }
    }
}
