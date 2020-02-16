using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Tool.Http;
using DemoInI;
using Native.Core.Domain;
using Newtonsoft.Json;

namespace Native.Core
{
    public class Getjson
    {
        InI ini = new InI(AppData.CQApi.AppDirectory + "main.ini");
        public string Get(string str)
        {
            string result;
            string Commandconfig = ini.ReadConfiguration("Command");
            int t = Commandconfig.Length;
            string left = str.Substring(0, t);
            string right = str.Substring(str.Length - t);
            string url = ini.ReadConfiguration("Url");
            byte[] get = HttpWebClient.Get(url+right);
            string Json = Encoding.UTF8.GetString(get);
            Root rt = JsonConvert.DeserializeObject<Root>(Json);
            int g;
            g = rt.code;
            if (g == 1)
            {
                result = "入库成功！\n内容为：" + right;
                return result;
            }
            else
            {
                result = "入库失败！";
                return result;
            }
            //return Json;
        }
    }
    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
    }
}
