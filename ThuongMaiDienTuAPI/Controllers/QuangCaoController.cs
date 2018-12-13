using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ThuongMaiDienTuAPI.Dtos;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;
using ThuongMaiDienTuAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThuongMaiDienTuAPI.Controllers
{
    [Route("api/[controller]")]
    public class QuangCaoController : Controller
    {
        IMapper _mapper;
        IQuangCaoService _quangCaoService;
        public QuangCaoController(IMapper _mapper, IQuangCaoService _quangCaoService)
        {
            this._mapper = _mapper;
            this._quangCaoService = _quangCaoService;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery]QuangCaoQuery query)
        {
            return Ok(await _quangCaoService.Get(query));
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] QuangCaoDto dto)
        {
            if(await _quangCaoService.Add(_mapper.Map<QuangCao>(dto)))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
