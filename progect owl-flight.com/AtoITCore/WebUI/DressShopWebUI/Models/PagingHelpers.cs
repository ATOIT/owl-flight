using System;
using System.Text;
using System.Web.Mvc;

namespace DressShopWebUI.Models
{
    /// <summary>
    /// Класс своих хелперов
    /// </summary>
    public static class PagingHelpers
    {
       /// <summary>
       /// HTML хелпер, для пейждинга
       /// </summary>
       /// <param name="html"></param>
       /// <param name="pageInfo"></param>
       /// <param name="pageUrl"></param>
       /// <returns></returns>
        public static MvcHtmlString PageLinks(this HtmlHelper html, PageInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            TagBuilder tagFirst = new TagBuilder("a");
            tagFirst.MergeAttribute("href", pageUrl(1));
            tagFirst.MergeAttribute("title", "в начало");
            tagFirst.InnerHtml = "&laquo";
            tagFirst.AddCssClass("pagination");
            result.Append(tagFirst);
            int count = 0;
           
            for (int i = pageInfo.PageNumber - 6 > 0 ? pageInfo.PageNumber - 5: 1 ; i <= pageInfo.TotalPages; i++)
            {
                if (count!=10)
                {
                    count++;
                    TagBuilder tag = new TagBuilder("a");
                    tag.MergeAttribute("href", pageUrl(i));
                    tag.MergeAttribute("title", "страница - "+i);
                    tag.InnerHtml = i.ToString();
                    if (i == pageInfo.PageNumber)
                    {
                        tag.AddCssClass("active");
                    }
                    tag.AddCssClass("pagination");
                    result.Append(tag);
                }
                
           }
            TagBuilder tagLast = new TagBuilder("a");
            tagLast.MergeAttribute("href", pageUrl(pageInfo.TotalPages));
            tagLast.MergeAttribute("title", "в конец");
            tagLast.InnerHtml = "&raquo;";
            tagLast.AddCssClass("pagination");
            result.Append(tagLast);
            
            return MvcHtmlString.Create(result.ToString());
        }
        //<div class="pagination">
        //   @Html.PageLinks(Model.PageInfo, x => Url.Action("Selling", new { page = x })) пример использования хелпера
        //</div>
    }
}