using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineMedicineShopping.Entities
{
    public class MedicineOrder
    {
        [Key]
        public int OrderId { get; set; }
        public int MedicineId { get; set; }
        public int UserId { get; set; }
        public ICollection<Medicine> Medicine { get; set; }
    }
}
