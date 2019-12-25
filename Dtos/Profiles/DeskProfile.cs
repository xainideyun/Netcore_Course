using AutoMapper;
using HT.P1.Jwt_Swagger.Dtos.Converters;
using HT.P1.Jwt_Swagger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HT.P1.Jwt_Swagger.Dtos.Profiles
{
    public class DeskProfile : Profile
    {
        public DeskProfile()
        {
            CreateMap<Desk, DeskDto>()
                //.ForMember(target => target.BuyTime, source => source.ConvertUsing(DateTimeToStringConverter.Instance))
                .ForMember(target => target.Shape, source => source.ConvertUsing(ShapeToStringConverter.Instance))
                .ReverseMap();
        }
    }
}
