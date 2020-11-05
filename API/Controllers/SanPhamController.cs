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
            model.id = Guid.NewGuid().ToString();
            sanpham.CreateSP(model);
            return model;
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
    }
}
