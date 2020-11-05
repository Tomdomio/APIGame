using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
   public interface ILichSuNapRepository
    {
        List<LichSuNapModel> GetbyidUser(string idUser);
        bool CreateNap(LichSuNapModel model);
    }
}
