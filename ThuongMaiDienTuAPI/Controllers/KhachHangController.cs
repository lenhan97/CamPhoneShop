using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Interfaces;
namespace ThuongMaiDienTuAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class KhachHangController : Controller
    {
        private IKhachHangService khachHangService;
        private IMapper mapper;
        public KhachHangController(IKhachHangService khachHangService, IMapper mapper)
        {
            this.khachHangService = khachHangService;
            this.mapper = mapper;
        }

        //[AllowAnonymous]
        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery] KhachHangQuery query)
        {
            return Ok(await khachHangService.Get(query));
        }
        [AllowAnonymous]
        [Route("getbyiduser")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdUser(int idUser)
        {
            return Ok(await khachHangService.GetByIdUser(idUser));
        }
    }
}