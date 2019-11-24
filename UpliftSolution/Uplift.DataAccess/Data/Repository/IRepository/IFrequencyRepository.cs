using System;
using System.Collections.Generic;
using System.Text;
using Uplift.Models;
namespace Uplift.DataAccess.Data.Repository.IRepository
{
    public interface IFrequencyRepository : IRepository<Frequency>
    {
        IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> GetFrequencyListForDropDown();

        void Update(Frequency frequency);
    }
}
