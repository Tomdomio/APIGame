using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class LichSuNapRepository: ILichSuNapRepository
    {
        
            private IDatabaseHelper _dbHelper;//khai báo một cái Idatabasehelper để lấy các hàm kết nối csdl
            public LichSuNapRepository(IDatabaseHelper dbHelper)
            {
                _dbHelper = dbHelper;//khởi tạo một Idatabasehelper, nếu không có thì lỗi
        }
        //lấy LichSutt theo USer
            public List<LichSuNapModel> GetbyidUser(string idUser)
            {
                string msgError = "";
                try
                {
                //dt = thủ tục trong csdl, sp_lichsutt_by_idUser là tên thủ tục
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_lichsunap_get_by_idUser",
                "@idUser", idUser);
                if (!string.IsNullOrEmpty(msgError))
                        throw new Exception(msgError);
                    return dt.ConvertTo<LichSuNapModel>().ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        public bool CreateNap(LichSuNapModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_napthe_create",
                "@id", model.id,
                "@idUser", model.idUser,
                "@nhamang", model.nhamang,
                "@mathe", model.mathe,
                "@soseri", model.soseri,
                "@menhgia", model.menhgia,
                "@ketqua", model.ketqua);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    }
