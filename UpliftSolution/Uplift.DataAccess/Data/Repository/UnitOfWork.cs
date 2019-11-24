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
        public IFrequencyRepository Frequency { get; private set; }
        public IServiceRepository Service { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            this._db = db;
            this.Category = new CategoryRepository(this._db);
            this.Frequency = new FrequencyRepository(this._db);
            this.Service = new ServiceRepository(this._db);
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
