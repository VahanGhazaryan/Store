﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Abstract
{
    public interface IUserRepository
    {
        bool Login(string username, string password);
        bool Logout();

        void SaveChnages();
    }
}
