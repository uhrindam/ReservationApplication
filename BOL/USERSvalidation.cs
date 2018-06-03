using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace BOL
{
    public class USERSvalidation
    {
        [Display(Name = "Felhasználónév")]
        [Required(ErrorMessage = "A felhasználó név mező kitöltése kötelező.")]
        public string NickName { get; set; }

        [Display(Name = "Teljes név")]
        [Required]
        public string FullName { get; set; }

        [Display(Name = "Emailcím")]
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

    //[MetadataType(typeof(USERSvalidation))]
    //public partial class USERS
    //{

    //}
}
