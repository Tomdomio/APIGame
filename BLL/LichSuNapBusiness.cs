using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class LichSuNapBusiness: ILichSuNapBusiness//kế thừa
    {
        private ILichSuNapRepository _res;//khai báo một interface dal tương ứng để dùng các hàm của dal
        public LichSuNapBusiness(ILichSuNapRepository ItemGroupRes)
        {
            _res = ItemGroupRes;//khởi tạo dal đó
        }
        public List<LichSuNapModel> theoidUser(string id)
        {
            return _res.GetbyidUser(id);//nếu có xử lý thêm thì viết ở đây
        }
        public bool CreateNap(LichSuNapModel model)
        {
            return _res.CreateNap(model);
        }
    }
}
