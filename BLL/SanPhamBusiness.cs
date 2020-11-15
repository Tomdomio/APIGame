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
        public bool CreateSP(SanPhamModel model)
        {
            return _res.CreateSP(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(SanPhamModel model)
        {
            return _res.Update(model);
        }
        public List<SanPhamModel> theoloai(string id)
        {
            return _res.GetByTheLoai(id);
        }
        public List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, string rank, string giaban)
        {
            return _res.Search(pageIndex, pageSize, out total, rank, giaban);
        }
    }

}
