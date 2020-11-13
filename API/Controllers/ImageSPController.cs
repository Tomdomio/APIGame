using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageSPController : ControllerBase
    {
        //khai báo bll tương ứng để dùng các hàm của bll
        private IImageSPBusiness image;
        private string _path;
        private string _pathh;

        public ImageSPController(IImageSPBusiness imagebns, IConfiguration configuration)
        {
            this.image = imagebns;
            _path = configuration["AppSettings:PATH"];
            _pathh = configuration["AppSettings:PATHH"];
        }
        //admin image
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
        //home image
        public string SaveFileFromBase64(string RelativePathFile, string dataFromBase64)
        {
            if (dataFromBase64.Contains("base64,"))
            {
                dataFromBase64 = dataFromBase64.Substring(dataFromBase64.IndexOf("base64,", 0) + 7);
            }
            return WriteFileHome(RelativePathFile, dataFromBase64);
        }
        public string WriteFileHome(string RelativePathFile, string base64Data)
        {
            try
            {
                string result = "";
                string serverRootPathFolderHome = _pathh;
                string fullPathFileHome = $@"{serverRootPathFolderHome}\{RelativePathFile}";
                string fullPathFolderHome = System.IO.Path.GetDirectoryName(fullPathFileHome);
                if (!Directory.Exists(fullPathFolderHome))
                    Directory.CreateDirectory(fullPathFolderHome);
                System.IO.File.WriteAllBytes(fullPathFileHome, Convert.FromBase64String(base64Data));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [Route("create-imagesp")]
        [HttpPost]
        public ImageSPModel Create([FromBody] ImageSPModel model)
        {
            if (model.image != null)
            {
                var arrData = model.image.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/Upload/SanPham/AnhCTSP/{arrData[0]}";
                    var savePathh = $@"assets/Upload/SanPham/AnhCTSP/{arrData[0]}";
                    model.image = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                    SaveFileFromBase64(savePathh, arrData[2]);
                }
            }
            model.id = Guid.NewGuid().ToString();
            image.Create(model);
            return model;
        }
        [Route("update-imagesp")]
        [HttpPost]
        public ImageSPModel Update([FromBody] ImageSPModel model)
        {
            if (model.image != null)
            {
                var arrData = model.image.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/Upload/SanPham/AnhCTSP/{arrData[0]}";
                    var savePathh = $@"assets/Upload/SanPham/AnhCTSP/{arrData[0]}";
                    model.image = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                    SaveFileFromBase64(savePathh, arrData[2]);
                }
            }
            image.Update(model);
            return model;
        }
        [Route("delete-imagesp")]
        [HttpPost]
        public IActionResult Delete([FromBody] Dictionary<string, object> formData)
        {
            string id = "";
            if (formData.Keys.Contains("id") && !string.IsNullOrEmpty(Convert.ToString(formData["id"]))) { id = Convert.ToString(formData["id"]); }
            image.Delete(id);
            return Ok();
        }
        [Route("get-by-sp/{id}")]
        [HttpGet]
        public IEnumerable<ImageSPModel> getbysanpham(string idsanpham)
        {
            return image.theosp(idsanpham).ToList();
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
                string idsanpham = "";
                if (formData.Keys.Contains("idsanpham") && !string.IsNullOrEmpty(Convert.ToString(formData["idsanpham"]))) { idsanpham = Convert.ToString(formData["idsanpham"]); }
                long total = 0;
                var data = image.Search(page, pageSize, out total, idsanpham);
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
