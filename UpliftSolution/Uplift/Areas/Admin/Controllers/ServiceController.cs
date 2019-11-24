using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Uplift.DataAccess.Data.Repository.IRepository;
using Uplift.Models.ViewModels;

namespace Uplift.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        [BindProperty]
        public ServiceViewModel ServiceViewModel { get; set; }
        public ServiceController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            this._unitOfWork = unitOfWork;
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            ServiceViewModel serviceViewModel = new ServiceViewModel()
            {
                Service = new Models.Service(),
                CategoryList = _unitOfWork.Category.GetCategoryListForDropDown(),
                FrequencyList = _unitOfWork.Frequency.GetFrequencyListForDropDown(),
            };

            if ( id != null)
            {
                serviceViewModel.Service = _unitOfWork.Service.Get(id.GetValueOrDefault());
            }

            return View(serviceViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        { 
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if ( ServiceViewModel.Service.Id == 0)
                {
                    
                    ServiceViewModel.Service.ImageUrl = CreateImageFile(webRootPath, files); 
                    _unitOfWork.Service.Add(ServiceViewModel.Service);
                }
                else
                {
                    // Edit existing service
                    var serviceFromDb = _unitOfWork.Service.Get(ServiceViewModel.Service.Id);
                    if( files.Count > 0 )
                    {                        
                        var imagePath = Path.Combine(webRootPath, serviceFromDb.ImageUrl.TrimStart('\\'));
                        if (DeleteImageFile(imagePath, serviceFromDb.ImageUrl))                        
                            ServiceViewModel.Service.ImageUrl = CreateImageFile(webRootPath, files);                        
                    }
                    else
                    {
                        ServiceViewModel.Service.ImageUrl = serviceFromDb.ImageUrl;
                    }
                    _unitOfWork.Service.Update(ServiceViewModel.Service);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ServiceViewModel.CategoryList = ServiceViewModel.CategoryList == null ? _unitOfWork.Category.GetCategoryListForDropDown() : ServiceViewModel.CategoryList;
                ServiceViewModel.FrequencyList = ServiceViewModel.FrequencyList == null ? _unitOfWork.Frequency.GetFrequencyListForDropDown() : ServiceViewModel.FrequencyList;
                return View(ServiceViewModel);
            }
            
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var serviceFromDb = _unitOfWork.Service.Get(id);
            string webRootPath = _hostEnvironment.WebRootPath;

            if ( serviceFromDb == null )
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            
            DeleteImageFile(webRootPath, serviceFromDb.ImageUrl);
            _unitOfWork.Service.Remove(serviceFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Error while deleting" });
            
        }


        private bool DeleteImageFile(string webRootPath, string imageUrl)
        {
            var imagePath = Path.Combine(webRootPath, imageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            return !System.IO.File.Exists(imagePath);
        }
        private string CreateImageFile(string webRootPath, Microsoft.AspNetCore.Http.IFormFileCollection files)
        {
            string fileName = Guid.NewGuid().ToString()+"_img_";
            var uploads = Path.Combine(webRootPath, @"images\services");
            var extension = Path.GetExtension(files[0].FileName);

            using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
            {
                files[0].CopyTo(fileStreams);
            }

            return @"\images\services\" + fileName + extension;
        }
        #region API Calls

        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Service.GetAll(includeProperties: "Category,Frequency" ) });
        }

        #endregion
    }
}