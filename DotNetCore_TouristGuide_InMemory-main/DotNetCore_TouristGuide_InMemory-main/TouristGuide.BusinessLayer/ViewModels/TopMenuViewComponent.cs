using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.BusinessLayer.Interfaces;

namespace TouristGuide.BusinessLayer.ViewModels
{
    public class TopMenuViewComponent : ViewComponent
    {
        private readonly ITourguideServices _tourguideServices;

        public TopMenuViewComponent(ITourguideServices tourguideServices)
        {
            _tourguideServices = tourguideServices;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _tourguideServices.DestinationList();
            return await Task.FromResult((IViewComponentResult)View("Default", model));
        }
    }
}
