using AutoMapper;
using HT.P1.Jwt_Swagger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HT.P1.Jwt_Swagger.Dtos.Profiles
{
    public class HomeProfile : Profile
    {
        public HomeProfile()
        {
            CreateMap<Home, HomeDto>();
        }
    }
}
