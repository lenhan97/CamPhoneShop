using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ThuongMaiDienTuAPI.Interfaces;
using ThuongMaiDienTuAPI.Dtos;
using ThuongMaiDienTuAPI.Dtos.Queries;
namespace ThuongMaiDienTuAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class SlideController : Controller
    {
        private ISlideService slideService;
        private IMapper mapper;
        public SlideController(ISlideService slideService, IMapper mapper)
        {
            this.slideService = slideService;
            this.mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery] SlideQuery query)
        {
            return Ok(await slideService.Get(query));
        }
    }
}