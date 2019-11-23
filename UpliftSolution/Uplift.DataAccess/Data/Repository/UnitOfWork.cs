using System;
using System.Collections.Generic;
using System.Text;
using Uplift.DataAccess.Data.Repository.IRepository;
namespace Uplift.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        ICategoryRepository IUnitOfWork.Category { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public UnitOfWork(ApplicationDbContext db)
        {
            this._db = db;
            Category = new CategoryRepository(this._db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            this._db.Dispose();
        }
    }
}
