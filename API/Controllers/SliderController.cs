﻿using System;
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
    public class SliderController : ControllerBase
    {
        //khai báo bll tương ứng để dùng các hàm của bll
        private ISliderBusiness slider;
        public SliderController(ILoaiBusiness sliderbsn)
        {
            this.slider = sliderbsn;
        }
        [Route("get-slider")]
        [HttpGet]//chúng ta cần cài method
        public IEnumerable<SliderModel> getslider()
        {
            return slider.get().ToList();
        }
    }
}
