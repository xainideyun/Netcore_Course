using AutoMapper;
using HT.P1.Jwt_Swagger.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HT.P1.Jwt_Swagger.Utils;

namespace HT.P1.Jwt_Swagger.Dtos.Converters
{
    public class ShapeToStringConverter : IValueConverter<Shape, string>
    {
        public static ShapeToStringConverter Instance { get; }
        static ShapeToStringConverter()
        {
            Instance = new ShapeToStringConverter();
        }

        public string Convert(Shape sourceMember, ResolutionContext context) => sourceMember.ToDescription();

    }
}
