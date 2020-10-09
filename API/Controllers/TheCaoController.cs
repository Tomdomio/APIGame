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
    public class TheCaoController : ControllerBase
    {
        //khai báo bll tương ứng để dùng các hàm của bll
        private ITheCaoBusiness thecao;
        public TheCaoController(ITheCaoBusiness thecaobsn)
        {
            this.thecao = thecaobsn;
        }
        [Route("get-thecao")]
        [HttpGet]//chúng ta cần cài method
        public IEnumerable<TheCaoModel> getthecao()
        {
            return thecao.get().ToList();
        }
    }
}
