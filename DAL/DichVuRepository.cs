using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DichVuRepository : IDichVuRepository
    {

        private IDatabaseHelper _dbHelper;//khai báo một cái Idatabasehelper để lấy các hàm kết nối csdl
        public DichVuRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;//khởi tạo một Idatabasehelper, nếu không có thì lỗi
        }
        //lấy loại
        public List<DichVuModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                //dt = thủ tục trong csdl, sp_theloai_all là tên thủ tục
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_dichvu_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DichVuModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(DichVuModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_dichvu_create",
                "@id", model.id,
                "@tendichvu", model.tendichvu,
                "@image", model.image);
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
        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_dichvu_delete",
                "@id", id);
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
        public bool Update(DichVuModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_dichvu_update",
                "@id", model.id,
                "@tendichvu", model.tendichvu,
                "@image", model.image);
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
        public List<DichVuModel> Search(int pageIndex, int pageSize, out long total, string tendichvu)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_dichvu_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@tentheloai", tendichvu);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<DichVuModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DichVuModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_dichvu_get_by_id",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DichVuModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
