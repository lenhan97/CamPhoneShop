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
        private IHoaDonService hoaDonService;
        private IMapper mapper;
        public HoaDonController(IHoaDonService hoaDonService, IMapper mapper)
        {
            this.hoaDonService = hoaDonService;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("getbyuser")]
        public async Task<IActionResult> GetByUser([FromQuery] HoaDonQuery query)
        {
            int idCustomer = User.GetIdCustomer();
            return Ok(await hoaDonService.GetByCustomer(idCustomer,query));
        }
        [Authorize(Roles ="SELLER")]
        [HttpGet]
        [Route("getbyseller")]
        public async Task<IActionResult> GetBySeller([FromQuery] HoaDonQuery query)
        {
            int idSeller = User.GetIdSeller();
            return Ok(await hoaDonService.GetBySeller(idSeller, query));
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
            catch(Exception ex){  } 
            return Ok(await hoaDonService.Add(idUser.GetValueOrDefault(),mapper.Map<HoaDon>(hoaDonDto)));
        }

    }
}