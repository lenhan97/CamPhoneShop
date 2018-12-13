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
    public class PageController : Controller
    {
        private IPageService pageService;
        private IMapper mapper;
        public PageController(IPageService pageService, IMapper mapper)
        {
            this.pageService = pageService;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery] PageQuery query)
        {
            return Ok(await pageService.Get(query));
        }
    }
}