
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
   public interface ILoaiRepository
    {
        public List<LoaiSanPhamModel> GetDataAll();
    }
}
