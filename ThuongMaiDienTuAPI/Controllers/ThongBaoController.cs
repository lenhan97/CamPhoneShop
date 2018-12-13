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
using ThuongMaiDienTuAPI.Helpers;
namespace ThuongMaiDienTuAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ThongBaoController : Controller
    {
        private IThongBaoService thongBaoService;
        private IMapper mapper;
        public ThongBaoController(IThongBaoService thongBaoService, IMapper mapper)
        {
            this.thongBaoService = thongBaoService;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery] ThongBaoQuery query)
        {
            int idUser = User.GetIdUser();
            return Ok(await thongBaoService.Get(idUser, query));
        }
        [HttpPut("{idThongBao}")]
        [Route("checkseen")]
        public async Task<IActionResult> CheckSeen(int idThongBao)
        {
            int idUser = User.GetIdUser();
            await thongBaoService.CheckSeen(idUser, idThongBao);
            return Ok();
        }
    }
}