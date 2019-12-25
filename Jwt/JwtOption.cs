using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HT.P1.Jwt_Swagger.Jwt
{
    public class JwtOption
    {
        /// <summary>
        /// 发布者
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// 接收者
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// 过期时间间隔（秒）
        /// </summary>
        public int ExpireSeconds { get; set; }
        /// <summary>
        /// 密钥
        /// </summary>
        public string SecurityKey { get; set; }
    }
}
