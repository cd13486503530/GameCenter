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

        private static string FileRoot
        {
            get { return ConfigurationManager.AppSettings["FilePath"] ?? string.Empty; }
        }



        public static string SaveFile(HttpPostedFileBase file, string tag)
        {
            if (file == null)
                return string.Empty;

            try
            {
                var ext = Path.GetExtension(file.FileName);
                var path = tag + DateTime.Now.ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo).Replace("/", "\\") + "\\";
                if (!File.Exists(FileRoot + path))
                {
                    Directory.CreateDirectory(FileRoot + path);
                }
                var randomFileName = DateTime.Now.ToString("yyyyMMddhhmmss") + new Random().Next(10000, 999999) + ext;
                var fileName = FileRoot + path + randomFileName;
                file.SaveAs(fileName);


                return path + randomFileName;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 用于保存图片，带缩略图
        /// </summary>
        /// <param name="file"></param>
        /// <param name="tag">图片路径标识</param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static string SaveImage(HttpPostedFileBase file, string tag, int width, int height)
        {
            var sourceFile = SaveFile(file, "\\Images\\" + tag + "\\big\\"); // 需要生成缩略图的源图片
            var newFilePath = "\\Images\\" + tag + "\\small\\" + DateTime.Now.ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo).Replace("/", "\\") + "\\"; //缩略图路径
            var ext = Path.GetExtension(file.FileName);//文件后缀
            var randomFileName = DateTime.Now.ToString("yyyyMMddhhmmss") + new Random().Next(10000, 999999) + ext;//随机文件名
            var newFileName = FileRoot + newFilePath + randomFileName;//缩略图完整路径
            if (!string.IsNullOrEmpty(sourceFile))
            {
                try
                {
                    MakeThumbnailImage(FileRoot + sourceFile, newFileName, width, height, 100);
                    return newFilePath + randomFileName;
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 缩略图生成
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="newFile"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="quality"></param>
        public static void MakeThumbnailImage(string sourceFile, string newFile, int width, int height, long quality)
        {
            if (width != 0 && height != 0)
                ImageUtil.MakeThumbnailImage(sourceFile, newFile, width, height, quality);
        }
    }
}
