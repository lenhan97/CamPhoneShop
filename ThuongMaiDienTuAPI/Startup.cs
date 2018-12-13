using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using ThuongMaiDienTuAPI.Helpers;
using Microsoft.EntityFrameworkCore;
using ThuongMaiDienTuAPI.Interfaces;
using ThuongMaiDienTuAPI.Services;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ThuongMaiDienTuAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddMvc(opts=>
            {
                opts.Filters.Add(typeof(ValidateModelAttribute));
            });
            //--------Swagger UI------------------
            services.AddSwaggerGen(x => x.SwaggerDoc("v1", new Info
            {
                Title = "Thuong mai dien tu API",
                Version = "v1"
            }));
            //--------Authentication--------------
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                op =>
                {
                    op.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        NameClaimType = JwtRegisteredClaimNames.Sub,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                }
            );
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
                });
            });
            //-------Connect database-------------
            services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("TMDTContext")));
            //---------Mapping Interface and Service-----------
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISanPhamService, SanPhamService>();
            services.AddScoped<IDanhMucSPService, DanhMucSPService>();
            services.AddScoped<IKhuyenMaiService, KhuyenMaiService>();
            services.AddScoped<IQuangCaoService, QuangCaoService>();
            services.AddScoped<ISlideService, SlideService>();
            services.AddScoped<IKhachHangService, KhachHangService>();
            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<IDanhGiaService, DanhGiaService>();
            services.AddScoped<IHoaDonService, HoaDonService>();
            services.AddScoped<IPageService, PageService>();
            services.AddScoped<IThongBaoService, ThongBaoService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            //------Swagger-----------
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contacts API V1");
            });
            //------Authentication------------
            //!!! Important use Auth need before use Mvc. 
            app.UseAuthentication();
            app.UseMvc();
            app.UseCors("EnableCORS");
        }
    }
}
