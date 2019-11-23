using System;
using System.Collections.Generic;
using System.Text;
using Uplift.Models;
namespace Uplift.DataAccess.Data.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Uplift.Models.Category>
    {
        IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> GetCategoryListforDropDown();

        void Update(Category category);
    }
}
