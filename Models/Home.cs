using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HT.P1.Jwt_Swagger.Models
{
    /// <summary>
    /// 家
    /// </summary>
    [Table("Home")]
    public class Home: BaseEntity
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double Lat { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double Lng { get; set; }
        /// <summary>
        /// 主人姓名
        /// </summary>
        public string HostName { get; set; }
        /// <summary>
        /// 房龄
        /// </summary>
        public int Age { get; set; }
    }
}
