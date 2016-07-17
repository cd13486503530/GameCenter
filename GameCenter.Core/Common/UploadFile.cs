using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeedIndex.Utility;
using System.Web;
using System.IO;
using System.Configuration;
using System.Globalization;

namespace GameCenter.Core.Common
{
    public class UploadFile
    {
        private const int MAX_SIZE = 5 * 1024 * 1024;
        private static string[] exts = { "jpg", "jpeg", "gif", "png" };
        public static bool Save(HttpPostedFile file, string path, string ext)
        {
            var fileName = DateTime.Now.ToString("yyyyMMddhhmmss") + new Random().Next(10000, 999999) + "." + ext;
            var result = WebUtil.UpLoad(file, MAX_SIZE, 1, exts, fileName);
            return result == UploadResult.Succed ? true : false;
        }


        public static string SaveFile(HttpPostedFileBase file)
        {
            if (file == null)
                return string.Empty;

            try
            {
                var ext = Path.GetExtension(file.FileName);
                var pathHeader = ConfigurationManager.AppSettings["FilePath"];
                var path = "\\upload\\" + DateTime.Now.ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo).Replace("/", "\\") + "\\";
                if (!File.Exists(pathHeader + path))
                {
                    Directory.CreateDirectory(pathHeader + path);
                }
                var randomFileName = DateTime.Now.ToString("yyyyMMddhhmmss") + new Random().Next(10000, 999999) + ext;
                var fileName = pathHeader + path + randomFileName;
                file.SaveAs(fileName);
                return path + randomFileName;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
