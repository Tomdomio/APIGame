using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IDichVuRepository
    {
        public List<DichVuModel> GetDataAll();
        DichVuModel GetDatabyID(string id);
        public bool Create(DichVuModel model);
        bool Update(DichVuModel model);
        bool Delete(string id);
        List<DichVuModel> Search(int pageIndex, int pageSize, out long total, string tendichvu);
    }
}
