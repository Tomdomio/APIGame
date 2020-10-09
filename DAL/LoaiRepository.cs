using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class LoaiRepository:ILoaiRepository
    {
        
            private IDatabaseHelper _dbHelper;//khai báo một cái Idatabasehelper để lấy các hàm kết nối csdl
            public LoaiRepository(IDatabaseHelper dbHelper)
            {
                _dbHelper = dbHelper;//khởi tạo một Idatabasehelper, nếu không có thì lỗi
        }
        //lấy loại
            public List<LoaiSanPhamModel> GetDataAll()
            {
                string msgError = "";
                try
                {
                //dt = thủ tục trong csdl, sp_theloai_all là tên thủ tục
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_theloai_all");
                    if (!string.IsNullOrEmpty(msgError))
                        throw new Exception(msgError);
                    return dt.ConvertTo<LoaiSanPhamModel>().ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
