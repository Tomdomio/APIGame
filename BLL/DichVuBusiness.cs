using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class DichVuBusiness : IDichVuBusiness//kế thừa
    {
        private IDichVuRepository _res;//khai báo một interface dal tương ứng để dùng các hàm của dal
        public DichVuBusiness(IDichVuRepository ItemGroupRes)
        {
            _res = ItemGroupRes;//khởi tạo dal
        }
        public List<DichVuModel> get()
        {
            return _res.GetDataAll();//nếu có xử lý thêm viết ở đây
        }
        public bool Create(DichVuModel model)
        {
            return _res.Create(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(DichVuModel model)
        {
            return _res.Update(model);
        }
        public List<DichVuModel> Search(int pageIndex, int pageSize, out long total, string tendichvu)
        {
            return _res.Search(pageIndex, pageSize, out total, tendichvu);
        }
        public DichVuModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
    }
}
