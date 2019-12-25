using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HT.P1.Jwt_Swagger.Dtos;
using HT.P1.Jwt_Swagger.Jwt;
using HT.P1.Jwt_Swagger.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HT.P1.Jwt_Swagger.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns></returns>
        [HttpPost("token")]
        [AllowAnonymous]
        public async Task<ActionResult<ApiResult>> GetToken([FromBody]UserDto user, [FromServices]IOptions<JwtOption> jwt)
        {
            var authClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString().ToLower())
            };
            var signKey = new SymmetricSecurityKey(jwt.Value.SecurityKey.ToBytes());
            var token = new JwtSecurityToken(
                jwt.Value.Issuer,
                jwt.Value.Audience,
                authClaims,
                expires: DateTime.Now.AddSeconds(Convert.ToInt32(jwt.Value.ExpireSeconds)),
                signingCredentials: new SigningCredentials(signKey, SecurityAlgorithms.HmacSha256)
                );
            await Task.CompletedTask;
            return Ok(new { Data = new { token = new JwtSecurityTokenHandler().WriteToken(token), expire = token.ValidTo } });
        }

    }
}