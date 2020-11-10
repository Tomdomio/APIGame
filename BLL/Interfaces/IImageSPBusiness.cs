using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IImageSPBusiness
    {
        List<ImageSPModel> theosp(string id);
        bool Create(ImageSPModel model);
        bool Update(ImageSPModel model);
        bool Delete(string id);
        List<ImageSPModel> Search(int pageIndex, int pageSize, out long total, string idsanpham);

    }
}
