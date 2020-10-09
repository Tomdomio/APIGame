using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class SliderRepository: ISliderRepository
    {
        
            private IDatabaseHelper _dbHelper;//khai báo một cái Idatabasehelper để lấy các hàm kết nối csdl
            public SliderRepository(IDatabaseHelper dbHelper)
            {
                _dbHelper = dbHelper;//khởi tạo một Idatabasehelper, nếu không có thì lỗi
        }
        //lấy loại
            public List<SliderModel> GetDataAll()
            {
                string msgError = "";
                try
                {
                //dt = hàm trong csdl, sp_theloai_all là tên hàm
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_slider_all");
                    if (!string.IsNullOrEmpty(msgError))
                        throw new Exception(msgError);
                    return dt.ConvertTo<SliderModel>().ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
