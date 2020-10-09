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
    public class DichVuController : ControllerBase
    {
        //khai báo bll tương ứng để dùng các hàm của bll
        private IDichVuBusiness dv;
        public DichVuController(IDichVuBusiness dichvubsn)
        {
            this.dv = dichvubsn;
        }
        [Route("get-dv")]
        [HttpGet]//chúng ta cần cài method
        public IEnumerable<DichVuModel> getdv()
        {
            return dv.get().ToList();
        }
    }
}
