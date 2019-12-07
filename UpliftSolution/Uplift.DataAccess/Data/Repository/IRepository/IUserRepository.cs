﻿using System;
using System.Collections.Generic;
using System.Text;
using Uplift.Models;
namespace Uplift.DataAccess.Data.Repository.IRepository
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        void LockUser(string userId);

        void UnlockUser(string userId);
        //void Update(string ApplicationUser);

    }
}
