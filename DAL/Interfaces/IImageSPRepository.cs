
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
   public interface IImageSPRepository
    {
        public List<ImageSPModel> GetDataAll();
        ImageSPModel GetDatabyID(string id);
        List<ImageSPModel> GetBySanPham(string idsanpham);
        public bool Create(ImageSPModel model);
        bool Update(ImageSPModel model);
        bool Delete(string id);
        List<ImageSPModel> Search(int pageIndex, int pageSize, out long total, string tentheloai);
    }
}
