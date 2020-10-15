using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class LichSuttBusiness: ILichSuttBusiness//kế thừa
    {
        private ILichSuttRepository _res;//khai báo một interface dal tương ứng để dùng các hàm của dal
        public LichSuttBusiness(ILichSuttRepository ItemGroupRes)
        {
            _res = ItemGroupRes;//khởi tạo dal đó
        }
        public List<LichSuttModel> theoidUser(string id)
        {
            return _res.GetbyidUser(id);//nếu có xử lý thêm thì viết ở đây
        }
    }
}
