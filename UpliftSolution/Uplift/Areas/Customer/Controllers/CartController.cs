using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uplift.DataAccess.Data.Repository.IRepository;
using Uplift.Extensions;
using Uplift.Models;
using Uplift.Models.ViewModels;
using Uplift.Utility;

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

        public IActionResult Summary()
        {
            var sessionList = HttpContext.Session.GetObject<List<int>>(Utility.StaticDetails.SessionCart);
            if (sessionList != null)
            {
                foreach (var serviceId in sessionList)
                {
                    cartViewModel.ServiceList.Add(_unitOfWork.Service.GetFirstOrDefault(u => u.Id == serviceId, includeProperties: "Frequency,Category"));
                }
            }
            return View(cartViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Summary")]
        public IActionResult SummaryPOST()
        {
            var sessionList = HttpContext.Session.GetObject<List<int>>(Utility.StaticDetails.SessionCart);
            if (sessionList != null)
            {
                cartViewModel.ServiceList = new List<Service>();
                foreach (var serviceId in sessionList)
                {
                    cartViewModel.ServiceList.Add(_unitOfWork.Service.Get(serviceId));
                }
            }

            if( !ModelState.IsValid )
                return View(cartViewModel);
            else
            {
                //Todo add transaction
                cartViewModel.OrderHeader.OrderDate = DateTime.Now;
                cartViewModel.OrderHeader.Status = StaticDetails.StatusSubmitted;
                cartViewModel.OrderHeader.ServiceCount = cartViewModel.ServiceList.Count;
                _unitOfWork.OrderHeader.Add(cartViewModel.OrderHeader);
                _unitOfWork.Save();

                foreach (var item in cartViewModel.ServiceList)
                {
                    OrderDetails orderDetails = new OrderDetails()
                    {
                        ServiceId = item.Id,
                        OrderHeaderId = cartViewModel.OrderHeader.Id,
                        ServiceName = item.Name, 
                        Price = item.Price
                    };
                    _unitOfWork.OrderDetails.Add(orderDetails);                    
                }
                _unitOfWork.Save();
                HttpContext.Session.SetObject(StaticDetails.SessionCart, new List<int>());
                return RedirectToAction("OrderConfirmation", "Cart", new { id = cartViewModel.OrderHeader.Id });
            }
        }

        public IActionResult OrderConfirmation(int id)
        {
            return View(id);
        }

        public IActionResult Remove(int serviceId)
        {
            var sessionList = HttpContext.Session.GetObject<List<int>>(Utility.StaticDetails.SessionCart);
            sessionList.Remove(serviceId);
            HttpContext.Session.SetObject(StaticDetails.SessionCart, sessionList);
            return RedirectToAction(nameof(Index));
        }
    }
}