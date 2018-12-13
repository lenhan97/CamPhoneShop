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
    public class SellerController : Controller
    {
        private ISellerService sellerService;
        private IMapper mapper;
        public SellerController(ISellerService sellerService, IMapper mapper)
        {
            this.sellerService = sellerService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery] SellerQuery query)
        {
            return Ok(await sellerService.Get(query));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        [Route("getbyiduser")]
        public async Task<IActionResult> GetByIdUser(int idUser)
        {
            return Ok(await sellerService.GetByIdUser(idUser));
        }

        [Authorize(Roles = "CUSTOMER")]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]SellerDto seller)
        {
            int idUser = User.GetIdUser();
            bool res = await sellerService.Register(idUser, mapper.Map<Seller>(seller));
            if (!res)
                return BadRequest();
            return Ok();
        }
        [Authorize(Roles = "CUSTOMER")]
        [HttpGet("{code}")]
        [Route("verifymail")]
        public async Task<IActionResult> VerifyMail(string code)
        {
            int idUser = User.GetIdUser();
            bool res = await sellerService.VerifyMail(idUser, code);
            if (!res)
                return BadRequest();
            return Ok();
        }

    }
}