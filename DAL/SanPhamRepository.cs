﻿using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class SanPhamRepository: ISanPhamRepository
    {
        
            private IDatabaseHelper _dbHelper;//khai báo một cái Idatabasehelper để lấy các hàm kết nối csdl
            public SanPhamRepository(IDatabaseHelper dbHelper)
            {
                _dbHelper = dbHelper;//khởi tạo một Idatabasehelper, nếu không có thì lỗi
        }
        //lấy loại
            public List<SanPhamModel> GetDataAll()
            {
                string msgError = "";
                try
                {
                //dt = hàm trong csdl, sp_theloai_all là tên hàm
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sanpham_all");
                    if (!string.IsNullOrEmpty(msgError))
                        throw new Exception(msgError);
                    return dt.ConvertTo<SanPhamModel>().ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
