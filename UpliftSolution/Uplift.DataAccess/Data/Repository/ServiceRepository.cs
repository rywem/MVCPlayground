using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uplift.Models;

namespace Uplift.DataAccess.Data.Repository
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        private readonly ApplicationDbContext _db;

        public ServiceRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }

        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
        {
            return _db.Category.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Service service)
        {
            var objFromDb = _db.Service.FirstOrDefault(s => s.Id == service.Id);

            objFromDb.Name = service.Name;
            objFromDb.LongDesc = service.LongDesc;
            objFromDb.Price = service.Price;
            objFromDb.ImageUrl = service.ImageUrl;
            objFromDb.CategoryId = service.CategoryId;
            objFromDb.FrequencyId = service.FrequencyId;
            
            _db.SaveChanges();
        }
    }
}
