using System;
using System.Collections.Generic;
using System.Text;
using Uplift.Models;
namespace Uplift.DataAccess.Data.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> GetCategoryListForDropDown();

        void Update(Category category);
    }
}
