using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class SanPhamBusiness: ISanPhamBusiness//kế thừa
    {
        private ISanPhamRepository _res;//khai báo một interface dal tương ứng để dùng các hàm của dal
        public SanPhamBusiness(ISanPhamRepository ItemGroupRes)
        {
            _res = ItemGroupRes;//khởi tạo dal đó
        }
        public List<SanPhamModel> get()
        {
            return _res.GetDataAll();//nếu có xử lý thêm thì viết ở đây
        }
        public SanPhamModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
     }
}
