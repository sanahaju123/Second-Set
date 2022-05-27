using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TouristGuide.Entities
{
    public class ContactUs
    {
        [Key]
        public int ContactId { get; set; }
        public double Phone { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
