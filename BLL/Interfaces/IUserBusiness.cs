using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IUserBusiness
    {
        UserModel Authenticate(string username, string password);
        UserModel GetDatabyID(string id);
        List<UserModel> get();
        bool CreateUser(UserModel model);
        bool Update(UserModel model);
        bool Delete(string id);
        List<UserModel> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan);
    }
}