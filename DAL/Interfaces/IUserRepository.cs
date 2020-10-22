using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
   public interface IUserRepository
    {
        public UserModel GetUser(string username, string password);
        public List<UserModel> GetDataAll();
        public UserModel GetDatabyID(string id);
        public bool Create(UserModel model);
        public bool Update(UserModel model);
        public bool Delete(string id);
        public List<UserModel> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan);
    }
}
