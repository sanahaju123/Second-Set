using OnlineMedicineShopping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineMedicineShopping.BusinessLayer.ViewModels
{
    public class MedicineViewModel
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int Discount { get; set; }
        public string Details { get; set; }
        public int Size { get; set; }
        public string Features { get; set; }
        public int CatId { get; set; }
        public MedicineOrder MedicineOrder { get; set; }
        public IEnumerable<Medicine> Medicines { get; set; }
        public int MedicinePerPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(Medicines.Count() / (double)MedicinePerPage));
        }
        public IEnumerable<Medicine> PaginatedInterview()
        {
            int start = (CurrentPage - 1) * MedicinePerPage;
            return Medicines.OrderBy(b => b.MedicineId).Skip(start).Take(MedicinePerPage);
        }
    }
}
