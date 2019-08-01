using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cities.Infrastructure.TagHelpers
{
    #region О дескрипторных вспомогательных классах
    /* Имя дескрипторного вспомогательного класса образуется из имени трансформируемого элемента и суффикса TagHelper. 
     * В рассматриваемом примере имя класса ButtonTagHelper сообщает инфраструктуре МVС о том, 
     * что это дескрипторный вспомогательный класс, который оперирует на элементах button.
     * Хотя получать доступ к деталям атрибутов элемента можно через словарь AllAttributes, 
     * более удобный подход предусматривает определение свойства, имя которого соответствует интересующему атрибуту.
     * В случае применения дескрипторного вспомогательного класса инфраструктура MVC инспектирует определенные 
     * им свойства и устанавливает значения любых из них, имена которых совпадают с атрибутами, примененными к НТМL-элементу.
     * Как часть этого процесса MVC будет пытаться преобразовать значение атрибута с целью соответствия типу свойства С#, 
     * так что свойства bool могут использоваться для получения значений булевских атрибутов (true и false), 
     * а свойства int - для получения значений числовых атрибутов (наподобие 1 и 2). 
     * 
     * 
     * Класс But tonTagHelper ограничен так, что он применяется только к элементам button, которые имеют атрибут bs-button-color,
     * а их родительским элементом является form. 
     */
    #endregion

    //[HtmlTargetElement("button",Attributes ="bs-button-color",ParentTag ="form")]       //Сужение области применения атрибута
    [HtmlTargetElement(Attributes ="bs-button-color",ParentTag ="form")]                //Расширение области применения атрибута (теперь атрибут можно применять и к элементам a)
    public class ButtonTagHelper:TagHelper
    {
        [HtmlAttributeName("bs-button-color")]
        public string BsButtonColor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", $"btn btn-{BsButtonColor}");
        }
    }
}
