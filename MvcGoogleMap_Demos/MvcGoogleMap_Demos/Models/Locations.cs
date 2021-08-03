using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcGoogleMap_Demos.Models
{
    public class Locations
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "*First Name and Last Name Required")]
        [Display(Name ="Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*City is Required")]
        public string City { get; set; }

        [Required(ErrorMessage = "*State is Required")]
        public string State { get; set; }

        [Required(ErrorMessage = "*Enter Valid PinCode Required")]
        [MinLength(6, ErrorMessage = "*PinCode must be of 6 digit")]
        [MaxLength(6, ErrorMessage = "*PinCode must not exceed 6 digit")]
        public string Pincode { get; set; }

        [Required(ErrorMessage = "*Latitude Required")]
        public Nullable<decimal> Latitude { get; set; }
        [Required(ErrorMessage = "*Longitude Required")]
        public Nullable<decimal> Longitude { get; set; }

        public string Description { get; set; }
    }
}