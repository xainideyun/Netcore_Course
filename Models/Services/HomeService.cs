using HT.P1.Jwt_Swagger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HT.P1.Jwt_Swagger.Models.Services
{
    public class HomeService : BaseService<Home>, IHomeService
    {
        public HomeService(JdDbContext dbContext) : base(dbContext)
        {
        }

    }
}
