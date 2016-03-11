using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace PAdControl.Serialize
{
    public class JsonHelper
    {
        /// <summary>
        /// 反序列化方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static T DeSerializerFromJson<T>(string jsonStr)
        {
            try
            {
                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonStr)))
                {
                    DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(T));
                    return (T)ds.ReadObject(ms);
                }
            }
            catch
            {
                return default(T);
            }
        }
    }
}
