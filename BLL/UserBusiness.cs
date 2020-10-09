using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class UserBusiness: IUserBusiness//kế thừa
    {
        private IUserRepository _res;//khai báo một interface dal tương ứng để dùng các hàm của dal
        public UserBusiness(IUserRepository ItemGroupRes)
        {
            _res = ItemGroupRes;//khởi tạo dal đó
        }
        public List<UserModel> get()
        {
            return _res.GetDataAll();//nếu có xử lý thêm thì viết ở đây
        }
    }
}
