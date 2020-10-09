using System;
using System.Collections.Generic;
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
    public class UserController : ControllerBase
    {
        //khai báo bll tương ứng để dùng các hàm của bll
        private IUserBusiness user;
        public UserController(IUserBusiness userbsn)
        {
            this.user = userbsn;
        }
        [Route("get-user")]
        [HttpGet]//chúng ta cần cài method
        public IEnumerable<UserModel> getuse()
        {
            return user.get().ToList();
        }
    }
}
