﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
   public interface IUserRepository
    {
         UserModel GetUser(string username, string password);
         List<UserModel> GetDataAll();
         UserModel GetDatabyID(string id);
         bool CreateUser(UserModel model);
         bool Update(UserModel model);
        bool UpdateMoney(UserModel model);
        bool Delete(string id);
         List<UserModel> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan);
    }
}
