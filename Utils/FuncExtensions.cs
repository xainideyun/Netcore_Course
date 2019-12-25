using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HT.P1.Jwt_Swagger.Utils
{
    public static class FuncExtensions
    {
        /// <summary>
        /// 获取指定枚举的描述
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum enumValue)
        {
            var value = enumValue.ToString();
            var field = enumValue.GetType().GetField(value);
            var objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);    //获取描述属性
            if (objs.Length == 0)
                return value;
            var descriptionAttribute = (DescriptionAttribute)objs[0];
            return descriptionAttribute.Description;
        }
        /// <summary>
        /// 获取枚举的描述与值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Dictionary<string, int> GetDescriptions<T>()where T: Enum
        {
            var type = typeof(T);
            var values = Enum.GetValues(type);
            var dic = new Dictionary<string, int>();
            foreach (var val in values)
            {
                dic.Add(Enum.GetName(type, val), (int)val);
            }
            return dic;
        }
        /// <summary>
        /// 获取byte[]
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] ToBytes(this string str)
        {
            return System.Text.Encoding.Default.GetBytes(str);
        }
    }
}
