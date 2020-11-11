using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.IO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DichVuController : ControllerBase
    {
        //khai báo bll tương ứng để dùng các hàm của bll
        private IDichVuBusiness dichvu;
        private string _path;
        public DichVuController(IDichVuBusiness dichvubsn, IConfiguration configuration)
        {
            this.dichvu = dichvubsn;
            _path = configuration["AppSettings:PATH"];
        }
        ////////////////////////////////////
        [Route("get-dv")]
        [HttpGet]//chúng ta cần cài method
        public IEnumerable<DichVuModel> getdv()
        {
            return dichvu.get().ToList();
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public DichVuModel GetDatabyID(string id)
        {
            return dichvu.GetDatabyID(id);
        }
        //////////Mã hóa image thành base64
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
        ///////////////////////////////////////////////////////////////////////////
        [Route("create-dv")]
        [HttpPost]
        public DichVuModel Createdichvu([FromBody] DichVuModel model)
        {
            if (model.image != null)
            {
                var arrData = model.image.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"Upload/DichVu/{arrData[0]}";
                    model.image = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            model.id = Guid.NewGuid().ToString();
            dichvu.Create(model);
            return model;
        }
        /////////////////////////////////////////
        [Route("update-dv")]
        [HttpPost]
        public DichVuModel UpdateDV([FromBody] DichVuModel model)
        {
            if (model.image != null)
            {
                var arrData = model.image.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"Upload/DichVu/{arrData[0]}";
                    model.image = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            dichvu.Update(model);
            return model;
        }
        [Route("delete-dv")]
        [HttpPost]
        public IActionResult Delete([FromBody] Dictionary<string, object> formData)
        {
            string id = "";
            if (formData.Keys.Contains("id") && !string.IsNullOrEmpty(Convert.ToString(formData["id"]))) { id = Convert.ToString(formData["id"]); }
            dichvu.Delete(id);
            return Ok();
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
                string tendichvu = "";
                if (formData.Keys.Contains("tendichvu") && !string.IsNullOrEmpty(Convert.ToString(formData["tendichvu"])))
                {
                    tendichvu = Convert.ToString(formData["tendichvu"]);
                }
                long total = 0;
                var data = dichvu.Search(page, pageSize, out total, tendichvu);
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
