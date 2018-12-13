using System.Collections.Generic;
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
    public class DanhMucSPController : Controller
    {
        private IDanhMucSPService danhMucSPService;
        private IMapper mapper;
        public DanhMucSPController(IDanhMucSPService danhMucSPService, IMapper mapper)
        {
            this.danhMucSPService = danhMucSPService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery] DanhMucSPQuery query)
        {
            GetResult rs = (ThuongMaiDienTuAPI.Helpers.GetResult)await danhMucSPService.Get(query);
            rs.Content = mapper.Map<List<DanhMucSPDto>>((List<DanhMucSP>)rs.Content);
            return Ok(rs.Get());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var danhmuc = await danhMucSPService.Get(new DanhMucSPQuery());
            return Ok(danhmuc);
        }


        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add([FromBody] DanhMucSPDto danhMucSPDto)
        {
            if (await danhMucSPService.Add(mapper.Map<DanhMucSP>(danhMucSPDto)))
                return Ok();
            return BadRequest();
        }
    }
}