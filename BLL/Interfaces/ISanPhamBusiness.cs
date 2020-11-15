using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ISanPhamBusiness
    {
        public List<SanPhamModel> get();
        SanPhamModel GetDatabyID(string id);
        List<SanPhamModel> GetByTheLoai(int pageIndex, int pageSize, out long total, string id_theloai);
        List<SanPhamModel> GetByLoai(string id);
        bool CreateSP(SanPhamModel model);
        bool Update(SanPhamModel model);
        bool Delete(string id);
        List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, string rank, string giaban);

    }
}
