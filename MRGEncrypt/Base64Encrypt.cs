using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Encrypt
{
    static class Base64Encrypt
    {
        /// <summary>
        /// 将文本转化为Base64编码格式
        /// </summary>
        public static string Encrypt(string text)
        {
            byte[] bytes = Encoding.Default.GetBytes(text);
            string base64Str = Convert.ToBase64String(bytes);
            return base64Str;
        }
        /// <summary>
        /// 将图片转化为Base64编码格式
        /// </summary>
        public static string EncryptPic(Bitmap pic, ImageFormat imageType)
        {
            MemoryStream m = new MemoryStream();
            pic.Save(m, imageType);
            byte[] b = m.GetBuffer();
            string base64string = Convert.ToBase64String(b);
            return base64string;
        }


        /// <summary>
        /// 将base64编码转化为文本
        /// </summary>
        public static string Decrypt(string base64string)
        {
            byte[] outputb = Convert.FromBase64String(base64string);
            string orgStr = Encoding.Default.GetString(outputb);
            return orgStr;
        }
        /// <summary>
        /// 将base64编码转化为图片
        /// </summary>
        public static Bitmap DecryptPic(string base64string)
        {
            byte[] bt = Convert.FromBase64String(base64string);
            System.IO.MemoryStream stream = new System.IO.MemoryStream(bt);
            Bitmap bitmap = new Bitmap(stream);
            return bitmap;
        }
    }
}
