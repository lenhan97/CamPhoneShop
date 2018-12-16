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
    [Route("api/[controller]")]
    [Authorize]
    public class SanPhamController : Controller
    {
        private ISanPhamService sanPhamService;
        private IMapper mapper;
        public SanPhamController(ISanPhamService sanPhamService, IMapper mapper)
        {
            this.sanPhamService = sanPhamService;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("get")]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery]SanPhamQuery query)
        {
            GetResult rs = (ThuongMaiDienTuAPI.Helpers.GetResult)await sanPhamService.Get(query);
            rs.Content = mapper.Map<List<SanPhamCommonViewDto>>((List<SanPham>)rs.Content);
            return Ok(rs.Get());
            //return Ok(mapper.Map<SanPhamCommonViewDto>(await sanPhamService.Get(query)));
        }
        [HttpGet]
        [Route("getbyseller")]
        [Authorize(Roles ="SELLER")]
        public async Task<IActionResult> GetBySeller([FromQuery]SanPhamQuery query)
        {
            int idSeller = User.GetIdSeller();
            return Ok(await sanPhamService.Get(idSeller, query));
        }

        [HttpPost]
        [Route("add")]
        //[AllowAnonymous]
        [Authorize(Roles = "SELLER")]
        public async Task<IActionResult> Add([FromBody]SanPhamDto sanPhamDto)
        {
            int idSeller = User.GetIdSeller();
            SanPham sanPham = mapper.Map<SanPham>(sanPhamDto);
            if (await sanPhamService.Add(idSeller, sanPham))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Route("delete")]
        [Authorize(Roles = "SELLER")]
        public async Task<IActionResult> Delete(int id)
        {
            int idSeller = User.GetIdSeller();
            if (await sanPhamService.Delete(idSeller, id))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Route("block")]
        [Authorize(Roles = "SELLER")]
        public async Task<IActionResult> Block(int id)
        {
            int idSeller = User.GetIdSeller();
            if (await sanPhamService.Block(idSeller, id))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("gettophot")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTopHot()
        {
            return Ok(await sanPhamService.GetTopBought());
        }
        [HttpGet]
        [Route("gettopsearch")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTopSearch()
        {
            return Ok(await sanPhamService.GetTopSearch());
        }

        [HttpGet]
        [Route("get/{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await sanPhamService.GetById(id));
        }
        [HttpPost]
        [Route("update")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(int id, [FromBody] SanPhamDto sanPhamDto)
        {
            int idSeller = 1; //User.GetIdSeller();
            SanPham sanPham = mapper.Map<SanPham>(sanPhamDto);
            sanPham.ID = id;
            if (await sanPhamService.Update(idSeller, sanPham))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}