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
    public class SanPhamController : ControllerBase
    {
        //khai báo bll tương ứng để dùng các hàm của bll
        private ISanPhamBusiness sanpham;

        public SanPhamController(ISanPhamBusiness sanphambns)
        {
            this.sanpham = sanphambns;
        }
        [Route("get-sanpham")]
        [HttpGet]//chúng ta cần cài method
        public IEnumerable<SanPhamModel> getsanpham()
        {
            return sanpham.get().ToList();
        }
    }
}
