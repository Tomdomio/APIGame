
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
   public interface ITheLoaiRepository
    {
        public List<TheLoaiModel> GetDataAll();
        public bool Create(TheLoaiModel model);
        bool Update(TheLoaiModel model);
        bool Delete(string id);
    }
}
