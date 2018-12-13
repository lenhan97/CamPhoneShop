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
    public class DanhGiaController : Controller
    {
        private IDanhGiaService danhGiaService;
        private IMapper mapper;
        public DanhGiaController(IDanhGiaService danhGiaService, IMapper mapper)
        {
            this.danhGiaService = danhGiaService;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("get")]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] DanhGiaQuery query)
        {
            return Ok(await danhGiaService.Get(query));
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] DanhGiaDto danhGiaDto)
        {
            int idUser = User.GetIdUser();
            if (await danhGiaService.Add(idUser, mapper.Map<DanhGia>(danhGiaDto)))
                return Ok();
            return BadRequest();
        }
    }
}