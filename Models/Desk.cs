using HT.P1.Jwt_Swagger.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HT.P1.Jwt_Swagger.Models
{
    [Table("Desk")]
    public class Desk: BaseEntity
    {
        /// <summary>
        /// 形状
        /// </summary>
        public Shape Shape { get; set; }
        /// <summary>
        /// 花费
        /// </summary>
        public double Cost { get; set; }
        /// <summary>
        /// 购买时间
        /// </summary>
        public DateTime? BuyTime { get; set; }
        /// <summary>
        /// 所属房子id
        /// </summary>
        public int? HomeId { get; set; }
        /// <summary>
        /// 所属房子
        /// </summary>
        public virtual Home Home { get; set; }
    }
}
