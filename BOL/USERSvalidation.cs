using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    class USERSvalidation
    {
        [Required]
        public string NickName { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Passwd { get; set; }
    }

    [MetadataType(typeof(USERSvalidation))]
    public partial class USERS
    {

    }
}
