using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HT.P1.Jwt_Swagger.Dtos
{
    public class HomeDto
    {
        public string Address { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string HostName { get; set; }
        public int Age { get; set; }
    }
}
