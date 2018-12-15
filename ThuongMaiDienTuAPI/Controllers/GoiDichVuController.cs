using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThuongMaiDienTuAPI.Dtos;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;
using ThuongMaiDienTuAPI.Helpers;
using ThuongMaiDienTuAPI.Interfaces;

namespace ThuongMaiDienTuAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class GoiDichVuController : Controller
    {
        private IGoiDichVuService goiDichVuService;
        private IMapper mapper;
        public GoiDichVuController(IGoiDichVuService goiDichVuService, IMapper mapper)
        {
            this.goiDichVuService = goiDichVuService;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery] GoiDichVuQuery query)
        {
            return Ok(await goiDichVuService.Get(query));
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(GoiDichVuDto goiDichVuDto)
        {
            GoiDichVu goiDichVu = mapper.Map<GoiDichVu>(goiDichVuDto);
            goiDichVu.TinhTrang = true;
            return Ok(await goiDichVuService.Add(goiDichVu));
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(GoiDichVu goiDichVu)
        {
            return Ok(await goiDichVuService.Update(goiDichVu));
        }


    }
}