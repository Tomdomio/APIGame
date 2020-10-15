using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class TheLoaiBusiness:ITheLoaiBusiness//kế thừa
    {
        private ITheLoaiRepository _res;//khai báo một interface dal tương ứng để dùng các hàm của dal
        public TheLoaiBusiness(ITheLoaiRepository ItemGroupRes)
        {
            _res = ItemGroupRes;//khởi tạo dal
        }
        public List<TheLoaiModel> get()
        {
            return _res.GetDataAll();//nếu có xử lý thêm viết ở đây
        }
        public bool Create(TheLoaiModel model)
        {
            return _res.Create(model);
        }
    }
}
