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
