using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HT.P1.Jwt_Swagger.Dtos.Converters
{
    public class DateTimeToStringConverter : IValueConverter<DateTime, string>
    {
        public static DateTimeToStringConverter Instance { get; }
        static DateTimeToStringConverter()
        {
            Instance = new DateTimeToStringConverter();
        }
        public string Convert(DateTime sourceMember, ResolutionContext context)
            => sourceMember.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
