using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Uplift.DataAccess.Data.Repository.IRepository;
using Uplift.Models;
namespace Uplift.DataAccess.Data.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }
        /*
        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
        {
            return _db.Category.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }*/
        /*
        public void Update(OrderHeader orderHeader)
        {
            var objFromDb = _db.OrderHeader.FirstOrDefault(s => s.Id == orderHeader.Id);

            objFromDb.Name = orderHeader.Name;
            objFromDb.Phone = orderHeader.Phone;
            objFromDb.Email = orderHeader.Email;
            objFromDb.Address = orderHeader.Address;
            objFromDb.State = orderHeader.State;
            objFromDb.ZipCode = orderHeader.ZipCode;
            objFromDb.OrderDate = orderHeader.OrderDate;
            objFromDb.Status = orderHeader.Status;
            objFromDb.Comments = orderHeader.Comments;
            objFromDb.ServiceCount = orderHeader.ServiceCount;
            _db.SaveChanges();
        }
        */
    }
}
