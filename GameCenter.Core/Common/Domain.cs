using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GameCenter.Core.Common
{
    public class Domain
    {
        public static string _imageSite;

        public static string MainUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["MainUrl"] ?? string.Empty;
            }
        }

        public static string MainUrlFull
        {
            get
            {
                return ConfigurationManager.AppSettings["MainUrlFull"] ?? string.Empty;
            }
        }

        static Domain()
        {
            _imageSite = ConfigurationManager.AppSettings["ImageSite"] ?? string.Empty;
        }

        /// <summary>
        /// 获取缩略图URL
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public string ImageBig(string imagePath)
        {
            return _imageSite + imagePath.Replace("\\", "/").Replace("small", "big");
        }

        /// <summary>
        /// 获取原图URL
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public static string ImageSmall(string imagePath)
        {
            return _imageSite + imagePath.Replace("\\", "/").Replace("big", "small");
        }

        /// <summary>
        /// 获取图片url
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public static string GetImage(string imagePath)
        {
            return _imageSite + imagePath.Replace("\\", "/");
        }
    }
}
