using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class LoaiBusiness:ILoaiBusiness//kế thừa
    {
        private ILoaiRepository _res;//khai báo một interface dal tương ứng để dùng các hàm của dal
        public LoaiBusiness(ILoaiRepository ItemGroupRes)
        {
            _res = ItemGroupRes;//khởi tạo dal đó
        }
        public List<LoaiSanPhamModel> get()
        {
            return _res.GetDataAll();//nếu có xử lý thêm thì viết ở đây
        }
    }
}
