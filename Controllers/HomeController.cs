using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HT.P1.Jwt_Swagger.Dtos;
using HT.P1.Jwt_Swagger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HT.P1.Jwt_Swagger.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HomeController : ControllerBase
    {
        private JdDbContext _context;
        private IMapper _mapper;
        public HomeController(JdDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// 获取家庭列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<HomeDto>>> Get()
        {
            var list = await _context.Homes.ToListAsync();
            var result = _mapper.Map<List<Home>, List<HomeDto>>(list);
            return result;
        }

    }
}