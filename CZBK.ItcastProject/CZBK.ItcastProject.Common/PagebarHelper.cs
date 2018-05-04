using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastProject.Common
{
    public class PagebarHelper
    {
        public static string GetPagebar(int pageIndex, int pageCount)
        {
            if (pageCount == 1)
            {
                return string.Empty;
            }

            int start = pageIndex - 5;
            if (start < 1)
            {
                start = 1;
            }

            int end = start + 9;
            if (end > pageCount)
            {
                end = pageCount;
                start = end - 9 < 1 ? 1 : end - 9;
            }

            StringBuilder sb = new StringBuilder();

            if (pageIndex > 1)
            {
                sb.AppendFormat("<a href='NumberPageCodeNewsList.aspx?pageIndex={0}'>前页</a>", pageIndex - 1);
            }
            else
            {
                sb.AppendFormat("<a href='NumberPageCodeNewsList.aspx?pageIndex={0}'>前页</a>", 1);
            }

            for (int i = start; i <= end; i++)
            {
                if (i == pageIndex)
                {
                    sb.AppendFormat("<a href='#'>{0}</a>", i);
                }
                else
                {
                    sb.AppendFormat("<a href='NumberPageCodeNewsList.aspx?pageIndex={0}'><span>{0}</span></a>", i);
                }
            }

            if (pageIndex != pageCount)
            {
                sb.AppendFormat("<a href='NumberPageCodeNewsList.aspx?pageIndex={0}'>后页</a>", pageIndex + 1);
            }
            else
            {
                sb.AppendFormat("<a href='NumberPageCodeNewsList.aspx?pageIndex={0}'>后页</a>", pageCount);
            }
            return sb.ToString();
        }
    }
}
