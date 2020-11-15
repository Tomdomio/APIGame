using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ImageSPRepository: IImageSPRepository
    {
        
            private IDatabaseHelper _dbHelper;//khai báo một cái Idatabasehelper để lấy các hàm kết nối csdl
            public ImageSPRepository(IDatabaseHelper dbHelper)
            {
                _dbHelper = dbHelper;//khởi tạo một Idatabasehelper, nếu không có thì lỗi
        }
        public List<ImageSPModel> GetBySanPham(string idsanpham)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_imagesp_get_by_idsanpham",
                     "@id_sanpham", idsanpham);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ImageSPModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(ImageSPModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_imagesp_create",
                "@id", model.id,
                "@id_sanpham", model.id_sanpham,
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_imagesp_delete",
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
        public bool Update(ImageSPModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_imagesp_update",
                "@id", model.id,
                "@id_sanpham", model.id_sanpham,
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
        public List<ImageSPModel> Search(int pageIndex, int pageSize, out long total, string id_sanpham)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_imagesp_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@id_sanpham", id_sanpham);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<ImageSPModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
