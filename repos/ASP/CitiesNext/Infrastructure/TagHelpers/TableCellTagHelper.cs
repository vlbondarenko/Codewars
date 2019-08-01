using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cities.Infrastructure.TagHelpers
{
    //С помощью аттрибута wrap внутрь html-элемента, например внутрь ячейки таблицы <td></td>, можно добавлять другие 
    //html-конструкции,например как в данном примере можно добавить конструкцию <b><i>...</i></b>, 
    //которая устанавливает жирный курсив строки врутри ячейки таблицы
    [HtmlTargetElement("td",Attributes ="wrap")]
    public class TableCellTagHelper:TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreContent.SetHtmlContent("<b><i>");
            output.PostContent.SetHtmlContent("</i></b>");
        }
    }
}
