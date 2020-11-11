using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        //khai báo bll tương ứng để dùng các hàm của bll
        private ISanPhamBusiness sanpham;
        private string _path;

        public SanPhamController(ISanPhamBusiness sanphambns)
        {
            this.sanpham = sanphambns;
        }
        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }
        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [Route("get-sanpham")]
        [HttpGet]//chúng ta cần cài method
        public IEnumerable<SanPhamModel> getsanpham()
        {
            return sanpham.get().ToList();
        }
        [Route("create-sanpham")]
        [HttpPost]
        public SanPhamModel CreateSP([FromBody] SanPhamModel model)
        {
            if (model.image != null)
            {
                var arrData = model.image.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"Upload/SanPham/{arrData[0]}";
                    model.image = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            model.id = Guid.NewGuid().ToString();
            sanpham.CreateSP(model);
            return model;
        }
        [Route("update-sanpham")]
        [HttpPost]
        public SanPhamModel UpdateSP([FromBody] SanPhamModel model)
        {
            if (model.image != null)
            {
                var arrData = model.image.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"Upload/SanPham/{arrData[0]}";
                    model.image = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            sanpham.Update(model);
            return model;
        }
        [Route("delete-sanpham")]
        [HttpPost]
        public IActionResult Delete([FromBody] Dictionary<string, object> formData)
        {
            string id = "";
            if (formData.Keys.Contains("id") && !string.IsNullOrEmpty(Convert.ToString(formData["id"]))) { id = Convert.ToString(formData["id"]); }
            sanpham.Delete(id);
            return Ok();
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public SanPhamModel GetDatabyID(string id)
        {
            return sanpham.GetDatabyID(id);
        }
        [Route("get-by-loai/{id}")]
        [HttpGet]
        public IEnumerable<SanPhamModel> getbytheloai(string id)
        {
            return sanpham.theoloai(id).ToList();
        }
        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string rank = "";
                if (formData.Keys.Contains("rank") && !string.IsNullOrEmpty(Convert.ToString(formData["rank"]))) { rank = Convert.ToString(formData["rank"]); }
                string giaban = "";
                if (formData.Keys.Contains("giaban") && !string.IsNullOrEmpty(Convert.ToString(formData["giaban"]))) { giaban = Convert.ToString(formData["giaban"]); }
                long total = 0;
                var data = sanpham.Search(page, pageSize, out total, rank, giaban);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}
