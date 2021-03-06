﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
   public interface ISanPhamRepository
    {
        public List<SanPhamModel> GetDataAll();
        SanPhamModel GetDatabyID(string id);
        List<SanPhamModel> GetByTheLoai(int pageIndex, int pageSize, out long total, string id_theloai);
        List<SanPhamModel> GetByLoai(string idtheloai);
        bool CreateSP(SanPhamModel model);
        bool Update(SanPhamModel model);
        bool Delete(string id);
        List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, string rank, string giaban);
    }
}
