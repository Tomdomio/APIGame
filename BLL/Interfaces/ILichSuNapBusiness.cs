using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ILichSuNapBusiness
    {
        List<LichSuNapModel> theoidUser(string id);
        bool CreateNap(LichSuNapModel model);
    }
}
