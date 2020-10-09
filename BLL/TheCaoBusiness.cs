using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class TheCaoBusiness: ITheCaoBusiness//kế thừa
    {
        private ITheCaoRepository _res;//khai báo một interface dal tương ứng để dùng các hàm của dal
        public TheCaoBusiness(ITheCaoRepository ItemGroupRes)
        {
            _res = ItemGroupRes;//khởi tạo dal đó
        }
        public List<TheCaoModel> get()
        {
            return _res.GetDataAll();//nếu có xử lý thêm thì viết ở đây
        }
    }
}
