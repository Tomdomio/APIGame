using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
   public interface ISanPhamRepository
    {
        public List<SanPhamModel> GetDataAll();
        SanPhamModel GetDatabyID(string id);
        List<SanPhamModel> GetByTheLoai(string idtheloai);
        bool CreateSP(SanPhamModel model);
    }
}
