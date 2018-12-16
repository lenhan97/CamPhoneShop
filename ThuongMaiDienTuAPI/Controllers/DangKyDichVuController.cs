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
    public class DangKyDichVuController : Controller
    {
        private IDangKyDichVuService dangKyDichVuService;
        private IMapper mapper;
        public DangKyDichVuController(IDangKyDichVuService dangKyDichVuService, IMapper mapper)
        {
            this.dangKyDichVuService = dangKyDichVuService;
            this.mapper = mapper;
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        [Route("getbyadmin")]
        public async Task<IActionResult> GetByAdmin([FromQuery] DangKyDichVuQuery query)
        {
            return Ok(await dangKyDichVuService.Get(query));
        }

        [Authorize(Roles = "SELLER")]
        [HttpGet]
        [Route("getbyseller")]
        public async Task<IActionResult> GetBySeller([FromQuery] DangKyDichVuQuery query)
        {
            query.IDSeller = User.GetIdSeller();
            return Ok(await dangKyDichVuService.Get(query));
        }

        [Authorize(Roles = "SELLER")]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(DangKyDichVuDto dangKyDichVuDto)
        {
            DangKyDichVu dangKyDichVu = mapper.Map<DangKyDichVu>(dangKyDichVuDto);
            dangKyDichVu.IDSeller = User.GetIdSeller();
            dangKyDichVu.ThoiGianDangKy = DateTime.Now.Date;
            if (await dangKyDichVuService.Add(dangKyDichVu))
            {
                return Ok();
            }
            return BadRequest();
        }


    }
}