using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThuongMaiDienTuAPI.Dtos;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;
using ThuongMaiDienTuAPI.Interfaces;
namespace ThuongMaiDienTuAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class KhachHangController : Controller
    {
        private IKhachHangService _khachHangService;
        private IMapper _mapper;
        public KhachHangController(IKhachHangService _khachHangService, IMapper _mapper)
        {
            this._khachHangService = _khachHangService;
            this._mapper = _mapper;
        }

        //[AllowAnonymous]
        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery] KhachHangQuery query)
        {
            return Ok(await _khachHangService.Get(query));
        }
        [AllowAnonymous]
        [Route("getbyiduser")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdUser(int idUser)
        {
            return Ok(await _khachHangService.GetByIdUser(idUser));
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] KhachHangDto khachhangdto)
        {
            if (await _khachHangService.Update(_mapper.Map<KhachHang>(khachhangdto)))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}