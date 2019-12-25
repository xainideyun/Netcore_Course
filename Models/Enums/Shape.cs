using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HT.P1.Jwt_Swagger.Models.Enums
{
    /// <summary>
    /// 形状
    /// </summary>
    public enum Shape
    {
        /// <summary>
        /// 未定义形状
        /// </summary>
        [Description("")]
        None = 0,
        /// <summary>
        /// 圆形
        /// </summary>
        [Description("圆形")]
        Circle = 1,
        /// <summary>
        /// 方形
        /// </summary>
        [Description("方形")]
        Square = 2,
        /// <summary>
        /// 星形
        /// </summary>
        [Description("星形")]
        Star = 3
    }
}
