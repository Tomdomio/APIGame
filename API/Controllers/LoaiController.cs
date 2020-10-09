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
    public class LoaiController : ControllerBase
    {
        //khai báo bll tương ứng để dùng các hàm của bll
        private ILoaiBusiness loai;
        public LoaiController(ILoaiBusiness loaibsn)
        {
            this.loai = loaibsn;
        }
        [Route("get-loai")]
        [HttpGet]//chúng ta cần cài method
        public IEnumerable<LoaiSanPhamModel> getloai()
        {
            return loai.get().ToList();
        }
    }
}
