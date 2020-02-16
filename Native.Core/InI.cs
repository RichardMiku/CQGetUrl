using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DemoInI
{
    public class InI
    {

        /// <summary>
        /// 写入INI文件
        /// </summary>
        /// <param name="section">节点名称[如[TypeName]]</param>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        /// <param name="filepath">文件路径</param>
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="section">节点名称</param>
        /// <param name="key">键</param>
        /// <param name="def">值</param>
        /// <param name="retval">stringbulider对象</param>
        /// <param name="size">字节大小</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);
        private string strFilePath = "";//获取INI文件路径
        private string strSec = ""; //INI文件名

        public InI(string _strFilePath)
        {
            strFilePath = _strFilePath;
        }
        /// <summary>
        /// 读取文件内容
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private string ContentValue(string section, string key)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, "", temp, 1024, strFilePath);
            return temp.ToString();
        }

        /// <summary>
        /// 写入节点
        /// </summary>
        /// <param name="name">查找节点的名字</param>
        /// <param name="text">写入节点的内容</param>
        /// <returns></returns>
        public string WriteConfiguration(string name, string text)
        {
            //根据INI文件名设置要写入INI文件的节点名称
            //此处的节点名称完全可以根据实际需要进行配置
            strSec = Path.GetFileNameWithoutExtension(strFilePath);
            WritePrivateProfileString(strSec, name, text, strFilePath);
            return "";
        }
        /// <summary>
        /// 读取ini文件 并返回
        /// </summary>
        /// <param name="text">查找节点的名字</param>
        /// <returns></returns>
        public string ReadConfiguration(string text)
        {
            strSec = Path.GetFileNameWithoutExtension(strFilePath);
            string texts = ContentValue(strSec, text);
            return texts;
        }
    }
}
