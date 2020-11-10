using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ITheLoaiBusiness
    {
        public List<TheLoaiModel> get();
        public bool Create(TheLoaiModel model);
        bool Update(TheLoaiModel model);
        bool Delete(string id);
    }
}
