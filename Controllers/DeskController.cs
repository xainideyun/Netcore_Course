using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HT.P1.Jwt_Swagger.Dtos;
using HT.P1.Jwt_Swagger.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HT.P1.Jwt_Swagger.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DeskController : ControllerBase
    {
        private JdDbContext _context;
        private IMapper _mapper;
        public DeskController(JdDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// 获取系统中所有的桌子
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<DeskDto>>> Get()
        {
            var list = await _context.Desks.ToListAsync();
            var result = _mapper.Map<List<Desk>, List<DeskDto>>(list);
            return result;
        }

        /// <summary>
        /// 创建桌子
        /// </summary>
        /// <param name="desk">桌子实体</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<DeskDto>> Post([FromBody]DeskDto desk)
        {
            var entity = _mapper.Map<DeskDto, Desk>(desk);
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<Desk, DeskDto>(entity);
            return result;
        }


    }
}