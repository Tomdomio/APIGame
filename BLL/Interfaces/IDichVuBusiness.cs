using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IDichVuBusiness
    {
        public List<DichVuModel> get();
        public bool Create(DichVuModel model);
        bool Update(DichVuModel model);
        bool Delete(string id);
        List<DichVuModel> Search(int pageIndex, int pageSize, out long total, string tendichvu);
        DichVuModel GetDatabyID(string id);
    }
}
