using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HF.PLM.Framework.EF
{
    public static class ExtensionMethod
    {
        /// <summary>
        /// 把对象转换为字符串对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None);
        }

        public static void UsingEx<T>(this T client, Action<T> work) where T : ICommunicationObject
        {
            work(client);
            try
            {
                client.Close();
            }
            catch
            {
                try
                {
                    client.Abort();
                }
                catch { }
            }
        }
    }
}
