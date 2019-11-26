using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uplift.DataAccess.Data.Repository.IRepository;
using Uplift.Extensions;
using Uplift.Models;
using Uplift.Models.ViewModels;

namespace Uplift.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public CartViewModel cartViewModel { get; set; }

        public CartController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            cartViewModel = new CartViewModel()
            { 
                OrderHeader = new OrderHeader(),
                ServiceList = new List<Service>()
            };
        }
        public IActionResult Index()
        {
            var sessionList = HttpContext.Session.GetObject<List<int>>(Utility.StaticDetails.SessionCart);
            if (sessionList != null )
            {
                foreach (var serviceId in sessionList)
                {
                    cartViewModel.ServiceList.Add(_unitOfWork.Service.GetFirstOrDefault(u => u.Id == serviceId, includeProperties: "Frequency,Category"));
                }
            }
            return View(cartViewModel);
        }
    }
}