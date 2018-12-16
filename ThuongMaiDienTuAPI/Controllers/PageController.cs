using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Interfaces;
namespace ThuongMaiDienTuAPI.Controllers
{
    [Route("api/[controller]")]
    public class PageController : Controller
    {
        private IPageService _pageService;
        private IMapper _mapper;
        public PageController(IPageService _pageService, IMapper _mapper)
        {
            this._pageService = _pageService;
            this._mapper = _mapper;
        }
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery] PageQuery query)
        {
            return Ok(await _pageService.Get(query));
        }
    }
}