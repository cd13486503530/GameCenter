using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Core.Common
{
   public class HttpClinetHelper
    {
        public static Task<string> GetAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetStringAsync(url);
                return result;
            }
        }
    }
}
