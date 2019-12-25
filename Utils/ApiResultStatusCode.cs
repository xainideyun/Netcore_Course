using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HT.P1.Jwt_Swagger.Utils
{
    public enum ApiResultStatusCode
    {
        [Display(Name = "成功")]
        Success = 0,

        [Display(Name = "服务器错误")]
        ServerError = 1,

        [Display(Name = "请求错误")]
        BadRequest = 2,

        [Display(Name = "未找到服务")]
        NotFound = 3,

        [Display(Name = "列表为空")]
        ListEmpty = 4,

        [Display(Name = "登录异常")]
        LogicError = 5,

        [Display(Name = "未认证")]
        UnAuthorized = 6
    }
}
