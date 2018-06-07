using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Premium.App.Models
{

    // This should ideally be in View Model than Model.
    // There is a tight coupling here.
    public class User
    {
        [Required(ErrorMessage = "The Name cannot be empty.")]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "The Date of Birth cannot be empty.")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "The Gender cannot be empty.")]
        public Gender Gender { get; set; }
    }
}
