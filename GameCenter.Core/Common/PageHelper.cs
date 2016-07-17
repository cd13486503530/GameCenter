using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeedIndex.Utility;

namespace GameCenter.Core.Common
{
    public class PageHelper
    {
        public static string ManagePager(int recordCount, int currentPage, int pageSize)
        { 
            return WebUtil.GetPaginationHtml(recordCount, currentPage, pageSize,pageArgumentName: "PageIndex",
                normalPageFormat: "<a class=\"paginate_button\" href=\"{0}\">{1}</a>",
                currentPageFormat: "<a class=\"paginate_button current\" >{1}</a>",
                previousPageFormat: "<a class=\"paginate_button previous disabled\" href=\"{0}\">上一页</a>",
                nextPageFormat: "<a class=\"paginate_button next\" href=\"{0}\">下一页</a>",
                lastPageFormat: null,
                gotoPageFormat: null,
                //paginationInfoFormat: "<span class=\"dataTables_info\">{0}/{1} 记录数:{2}</span> ",
                paginationInfoFormat:null,
                firstPageFormat:null
                ); 
        }
    }
}
