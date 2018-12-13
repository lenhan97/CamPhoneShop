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
    [Route("api/[controller]")]
    [Authorize]
    public class KhuyenMaiController : Controller
    {
        private IKhuyenMaiService _khuyenMaiService;
        private IMapper _mapper;

        public KhuyenMaiController(IKhuyenMaiService khuyenMaiService, IMapper mapper)
        {
            this._khuyenMaiService = khuyenMaiService;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery] KhuyenMaiQuery query)
        {
            return Ok(await _khuyenMaiService.Get(query));
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] KhuyenMaiDto khuyenMaiDto)
        {
            int idUser = User.GetIdUser();
            if (await _khuyenMaiService.Add(idUser,_mapper.Map<KhuyenMai>(khuyenMaiDto)))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
