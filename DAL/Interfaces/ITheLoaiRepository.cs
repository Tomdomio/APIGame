
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
   public interface ITheLoaiRepository
    {
        public List<TheLoaiModel> GetDataAll();
        TheLoaiModel GetDatabyID(string id);
        public bool Create(TheLoaiModel model);
        bool Update(TheLoaiModel model);
        bool Delete(string id);
        List<TheLoaiModel> Search(int pageIndex, int pageSize, out long total, string tentheloai);
    }
}
