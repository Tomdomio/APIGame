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
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(TheLoaiModel model)
        {
            return _res.Update(model);
        }
        public List<TheLoaiModel> Search(int pageIndex, int pageSize, out long total, string tentheloai)
        {
            return _res.Search(pageIndex, pageSize, out total, tentheloai);
        }
        public TheLoaiModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
    }
}
