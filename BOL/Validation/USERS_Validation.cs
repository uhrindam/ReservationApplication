using BOL;
using BOL.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    /// <summary>
    /// In this class I give attributes to the properties, for the valdation.
    /// </summary>
    public class USERS_Validation
    {
        [Required]
        [UniqueNickName]
        [Display(Name = "Felhasználó név")]
        public string NickName { get; set; }

        [Required]
        [Display(Name = "Teljes név")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Emailcím")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Jelszó")]
        public string Passwd { get; set; }

        [Display(Name = "Regisztráció dátuma")]
        public Nullable<System.DateTime> RegistrationDate { get; set; }

        [Display(Name = "Admin-e")]
        public Nullable<bool> IsAdmin { get; set; }
    }

    [MetadataType(typeof(USERS_Validation))]
    public partial class USERS
    {

    }
}
