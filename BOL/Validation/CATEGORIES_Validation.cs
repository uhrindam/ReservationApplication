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
