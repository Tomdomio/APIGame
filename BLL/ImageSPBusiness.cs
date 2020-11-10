using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class ImageSPBusiness: IImageSPBusiness//kế thừa
    {
        private IImageSPRepository _res;//khai báo một interface dal tương ứng để dùng các hàm của dal
        public ImageSPBusiness(IImageSPRepository ItemGroupRes)
        {
            _res = ItemGroupRes;//khởi tạo dal
        }
        public bool Create(ImageSPModel model)
        {
            return _res.Create(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(ImageSPModel model)
        {
            return _res.Update(model);
        }
        public List<ImageSPModel> Search(int pageIndex, int pageSize, out long total, string idsanpham)
        {
            return _res.Search(pageIndex, pageSize, out total, idsanpham);
        }
        public List<ImageSPModel> theosp(string idsanpham)
        {
            return _res.GetBySanPham(idsanpham);//nếu có xử lý thêm thì viết ở đây
        }
    }
}
