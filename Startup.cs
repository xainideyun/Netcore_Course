using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HT.P1.Jwt_Swagger.Jwt;
using HT.P1.Jwt_Swagger.Models;
using HT.P1.Jwt_Swagger.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace HT.P1.Jwt_Swagger
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(option =>
                {
                    option.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                });

            services.AddDbContext<JdDbContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("defaultConnection"))     // 使用sqlserver数据库
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)                 // 查询时不跟踪实体对象
                );

            #region AutoMapper

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #endregion

            #region JWT

            var jwtOption = new JwtOption();
            Configuration.GetSection("JwtSettings").Bind(jwtOption);
            services.Configure<JwtOption>(Configuration.GetSection("JwtSettings"));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.SaveToken = true;
                    option.RequireHttpsMetadata = false;
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtOption.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwtOption.Audience,
                        RequireExpirationTime = true,
                        ClockSkew = new TimeSpan(0, 0, Convert.ToInt32(jwtOption.ExpireSeconds)),
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(jwtOption.SecurityKey.ToBytes())
                    };
                });

            #endregion

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Netcore通用解决方案",
                    Version = "v1",
                    //Description = "Netcore3.1/AutoMapper/Swagger/Jwt/Filter",
                    //TermsOfService = new Uri("https://www.baidu.com"),
                    //Contact = new OpenApiContact { Email = "sunxsalyr@hotmail.com", Name = "孙小双", Url = new Uri("https://www.baidu.com") },
                    //License = new OpenApiLicense { Name = "中铁五院", Url = new Uri("https://www.baidu.com") }
                });

                // 将Swagger设置为按照生成的XML文件显示的格式
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                // 为swagger添加jwt验证
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "请输入bearer",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference()
                                {
                                    Id = "Bearer",
                                    Type = ReferenceType.SecurityScheme
                                }
                            }, Array.Empty<string>()
                        }
                    });

            });

            #endregion



        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Netcore通用解决方案");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthentication();                // 认证中间件

            app.UseAuthorization();                 // 授权中间件

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
