using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MRGINI
{
    public class INIProcessor
    {
        private string iniFullFilePath;//程序完整的地址（直到文件扩展名）

        public INIProcessor(string path)
        {
            this.iniFullFilePath = path;
        }

        /// <summary>
        /// 写入到INI文件
        /// </summary>
        /// <param name="section">所属字段</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public long WriteToIni(string section, string key , string value)
        {
            long ret = WritePrivateProfileString(section, key, value, this.iniFullFilePath);
            return ret;
        }

        /// <summary>
        /// 读取INI文件中的数据
        /// </summary>
        /// <param name="Section">所属字段</param>
        /// <param name="key">键</param>
        /// <returns>返回获取到的值</returns>
        public string ReadFromIni(string section,string key)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, "", temp, 1024, this.iniFullFilePath);
            return temp.ToString();
        }


        #region WIN32API
        /// <summary>
        /// 写入INI文件
        /// </summary>
        /// <param name="section">节点名称[如[TypeName]]</param>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        /// <param name="filepath">文件路径</param>
        /// <returns></returns>
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
        #endregion
    }
}
