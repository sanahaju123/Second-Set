using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineMedicineShopping.Entities
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Stock { get; set; }
        public int Discount { get; set; }
        [Required]
        public string Details { get; set; }
        public string Size { get; set; }
        [Required]
        public string Features { get; set; }
        [Required]
        public int CatId { get; set; }
    }
}
