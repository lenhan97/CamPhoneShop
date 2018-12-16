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
    public class HoaDonController : Controller
    {
        private IHoaDonService _hoaDonService;
        private IMapper _mapper;
        public HoaDonController(IHoaDonService _hoaDonService, IMapper _mapper)
        {
            this._hoaDonService = _hoaDonService;
            this._mapper = _mapper;
        }
        [HttpGet]
        [Route("getbyuser")]
        public async Task<IActionResult> GetByUser([FromQuery] HoaDonQuery query)
        {
            int idCustomer = User.GetIdCustomer();
            return Ok(await _hoaDonService.GetByCustomer(idCustomer,query));
        }
        [Authorize(Roles ="SELLER")]
        [HttpGet]
        [Route("getbyseller")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetBySeller([FromQuery] HoaDonQuery query)
        {
            int idSeller = User.GetIdSeller();
            return Ok(await _hoaDonService.GetBySeller(idSeller, query));
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] HoaDonDto hoaDonDto)
        {
            int? idUser = null;
            try
            {
                idUser = User.GetIdUser();
            }
            catch (Exception)
            { }
            return Ok(await _hoaDonService.Add(idUser.GetValueOrDefault(),_mapper.Map<HoaDon>(hoaDonDto)));
        }

        [HttpPut]
        [Route("update")]
        [Authorize(Roles ="SELLER")]
        //[AllowAnonymous]
        public async Task<IActionResult> Update(int id, string paymentStatus)
        {
            var idSeller = User.GetIdSeller();

            if (await _hoaDonService.Update(idSeller, id, paymentStatus))
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}