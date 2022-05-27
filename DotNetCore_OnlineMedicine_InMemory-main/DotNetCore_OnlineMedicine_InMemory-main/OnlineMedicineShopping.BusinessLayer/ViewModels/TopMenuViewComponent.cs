using Microsoft.AspNetCore.Mvc;
using OnlineMedicineShopping.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMedicineShopping.BusinessLayer.ViewModels
{
    public class TopMenuViewComponent : ViewComponent
    {
        private readonly IMedicineServices _medicineServices;

        public TopMenuViewComponent(IMedicineServices medicineServices)
        {
            _medicineServices = medicineServices;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _medicineServices.CatList();
            return await Task.FromResult((IViewComponentResult)View("Default", model));
        }
    }
}
