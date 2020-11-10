using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class UsersController : ControllerBase
    {
        private IUserBusiness users;
        private string _path;
        public UsersController(IUserBusiness userbsn, IConfiguration configuration)
        {
            users = userbsn;
            _path = configuration["AppSettings:PATH"];
        }
            [AllowAnonymous]
            [HttpPost("authenticate")]
            public IActionResult Authenticate([FromBody] AuthenticateModel model)
            {
            var user = users.Authenticate(model.Username, model.Password);

                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                return Ok(user);
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
          [Route("get-user")]
          [HttpGet]//chúng ta cần cài method
            public IEnumerable<UserModel> getuser()
            {
                return users.get().ToList();
            }
            [Route("create-user")]
            [HttpPost]
            public UserModel CreateUser([FromBody] UserModel model)
            {
                model.id = Guid.NewGuid().ToString();
                users.CreateUser(model);
                return model;
            }
        [Route("update-user")]
        [HttpPost]
        public UserModel UpdateUser([FromBody] UserModel model)
        {
            users.Update(model);
            return model;
        }
        [Route("delete-user")]
            [HttpPost]
            public IActionResult Delete([FromBody] Dictionary<string, object> formData)
            {
                string id = "";
                if (formData.Keys.Contains("id") && !string.IsNullOrEmpty(Convert.ToString(formData["id"]))) { id = Convert.ToString(formData["id"]); }
                users.Delete(id);
                return Ok();
            }
            [Route("get-by-id/{id}")]
            [HttpGet]
            public UserModel GetDatabyID(string id)
            {
                return users.GetDatabyID(id);
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
                    string hoten = "";
                    if (formData.Keys.Contains("hoten") && !string.IsNullOrEmpty(Convert.ToString(formData["hoten"]))) { hoten = Convert.ToString(formData["hoten"]); }
                    string taikhoan = "";
                    if (formData.Keys.Contains("taikhoan") && !string.IsNullOrEmpty(Convert.ToString(formData["taikhoan"]))) { hoten = Convert.ToString(formData["taikhoan"]); }
                    long total = 0;
                    var data = users.Search(page, pageSize, out total, hoten, taikhoan);
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