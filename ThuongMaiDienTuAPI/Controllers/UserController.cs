using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ThuongMaiDienTuAPI.Dtos;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;
using ThuongMaiDienTuAPI.Helpers;
using ThuongMaiDienTuAPI.Interfaces;

namespace ThuongMaiDienTuAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        private IUserService userService;
        private readonly IConfiguration config;
        private IMapper mapper;
        public UserController(IUserService userService,IConfiguration config,IMapper mapper)
        {
            this.userService = userService;
            this.config = config;
            this.mapper = mapper;
        }
        //[AllowAnonymous]
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery] UserQuery query)
        {
            dynamic user = await userService.Get(query);
            object res = new
            {
                Total=user.Total,
                Content= mapper.Map<IEnumerable<UserDto>>(user.Content)
            };
            return Ok(res);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginDto login)
        {
            var user = await userService.Login(login);
            if (user != null && user.TinhTrang == true) 
            {
                return Ok(new { Token = BuildToken(mapper.Map<UserDto>(user)) });
            }
            return Unauthorized();
        }

        private string BuildToken(UserDto user)
        {
            Claim newClaim = null;
            if(user.LoaiUser==ConstantVariable.UserPermission.SELLER)
            {
                newClaim = new Claim("IDSeller", user.IDSeller.ToString());
            }

            var claims = new[]
            {
                new Claim("ID",user.ID.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub,user.TenDN),
                new Claim(ClaimTypes.Role,user.LoaiUser),
                new Claim("IDCustomer",user.IDKhachHang.ToString()),
                newClaim,
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] RegisterDto register)
        {
            KhachHang khachHang = mapper.Map<KhachHang>(register);
            User user = mapper.Map<User>(register);
            bool result = await userService.Add(khachHang, user);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}