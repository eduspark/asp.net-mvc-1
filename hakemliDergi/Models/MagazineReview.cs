using prj.Models.atr;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prj.Models
{
    public class MagazineReview : IValidatableObject
    {
        public int Id { get; set; }

        [Range(1,10,ErrorMessage = "Rate between 1-10")]
        [Required]
        public int Rating { get; set; }

        [Required]
        [StringLength(1024)]
        public string Body { get; set; }

        [Display(Name="User Name")]
        [DisplayFormat(NullDisplayText="anonymous")]
        [MaxWords(4)]
        public string ReviewerName { get; set; }
        public int MagazineId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Rating < 2 && ReviewerName.ToLower().StartsWith("kemal"))
            {
                yield return new ValidationResult("Sorry, kilicdaroglu, you can't do this");
            }
        }
    }
}