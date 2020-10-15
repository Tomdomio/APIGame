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
    public class LichSuttController : ControllerBase
    {
        //khai báo bll tương ứng để dùng các hàm của bll
        private ILichSuttBusiness lichsutt;

        public LichSuttController(ILichSuttBusiness lichsubns)
        {
            this.lichsutt= lichsubns;
        }
        [Route("get-by-idUser/{id}")]
        [HttpGet]
        public IEnumerable<LichSuttModel> getbyidUser(string id)
        {
            return lichsutt.theoidUser(id).ToList();
        }
    }
}
