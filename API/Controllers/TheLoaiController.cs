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
    public class TheLoaiController : ControllerBase
    {
        //khai báo bll tương ứng để dùng các hàm của bll
        private ITheLoaiBusiness theloai;
        private string _path;
        public TheLoaiController(ITheLoaiBusiness theloaibsn, IConfiguration configuration)
        {
            this.theloai = theloaibsn;
            _path = configuration["AppSettings:PATH"];
        }
////////////////////////////////////
        [Route("get-theloai")]
        [HttpGet]//chúng ta cần cài method
        public IEnumerable<TheLoaiModel> gettheloai()
        {
            return theloai.get().ToList();
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public TheLoaiModel GetDatabyID(string id)
        {
            return theloai.GetDatabyID(id);
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
        [Route("create-theloai")]
        [HttpPost]
        public TheLoaiModel CreateTheLoai([FromBody] TheLoaiModel model)
        {
            if (model.image != null)
            {
                var arrData = model.image.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/Upload/TheLoai/{arrData[0]}";
                    model.image = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            model.id = Guid.NewGuid().ToString();
            theloai.Create(model);
            return model;
        }
        /////////////////////////////////////////
        [Route("update-theloai")]
        [HttpPost]
        public TheLoaiModel UpdateTL([FromBody] TheLoaiModel model)
        {
            theloai.Update(model);
            return model;
        }
        [Route("delete-theloai")]
        [HttpPost]
        public IActionResult Delete([FromBody] Dictionary<string, object> formData)
        {
            string id = "";
            if (formData.Keys.Contains("id") && !string.IsNullOrEmpty(Convert.ToString(formData["id"]))) { id = Convert.ToString(formData["id"]); }
            theloai.Delete(id);
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
                string tentheloai = "";
                if (formData.Keys.Contains("tentheloai") && !string.IsNullOrEmpty(Convert.ToString(formData["tentheloai"]))) {
                    tentheloai = Convert.ToString(formData["tentheloai"]);
                }
                long total = 0;
                var data = theloai.Search(page, pageSize, out total, tentheloai);
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
