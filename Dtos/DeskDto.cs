using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HT.P1.Jwt_Swagger.Dtos
{
    public class DeskDto
    {
        public int Id { get; set; }
        public string Shape { get; set; }
        public double Cost { get; set; }
        public DateTime? BuyTime { get; set; }
        public int? HomeId { get; set; }
    }
}
