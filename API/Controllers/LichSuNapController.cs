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
    public class LichSuNapController : ControllerBase
    {
        //khai báo bll tương ứng để dùng các hàm của bll
        private ILichSuNapBusiness lichsunap;

        public LichSuNapController(ILichSuNapBusiness lichsunapbns)
        {
            this.lichsunap= lichsunapbns;
        }
        [Route("get-by-idUser/{id}")]
        [HttpGet]
        public IEnumerable<LichSuNapModel> getbyidUser(string id)
        {
            return lichsunap.theoidUser(id).ToList();
        }
        [Route("create-nap")]
        [HttpPost]
        public LichSuNapModel CreateUser([FromBody] LichSuNapModel model)
        {
            model.id = Guid.NewGuid().ToString();
            lichsunap.CreateNap(model);
            return model;
        }
    }
}
