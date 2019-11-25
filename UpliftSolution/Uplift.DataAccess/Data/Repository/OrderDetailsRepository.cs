using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Uplift.DataAccess.Data.Repository.IRepository;
using Uplift.Models;
namespace Uplift.DataAccess.Data.Repository
{
    public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderDetailsRepository(ApplicationDbContext db) : base(db)
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
        }
        */
        /*
        public void Update(OrderDetails orderDetails)
        {
            var objFromDb = _db.OrderDetails.FirstOrDefault(s => s.Id == orderDetails.Id);

            objFromDb.OrderHeaderId = orderDetails.OrderHeaderId;
            objFromDb.ServiceId = orderDetails.ServiceId;
            objFromDb.ServiceName = orderDetails.ServiceName;
            objFromDb.Price = orderDetails.Price;

            _db.SaveChanges();
        }*/
    }
}
