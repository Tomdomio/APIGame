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
        List<SanPhamModel> theoloai(string id);
    }
}
