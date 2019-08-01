using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsingViewComponent.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Html;

namespace UsingViewComponent.Components
{
    public class CitySummary:ViewComponent
    {
        private ICityRepository repository;

        public CitySummary(ICityRepository repo)
        {
            repository = repo;
        }

        #region Возвращение представления из компонента
        //Здесь метод возвращает представление, расположенное по пути Views\Home\Components\CitySummary\Default.cshtml
        //Метод Invoke возвращает объект ViewViewComponentResult
        //В это представление передается модель CityViewModel
        //Таким образом в одно родительское строо типизированное представление можно добавить частичные представлениясо своими данными
        //Метод View() в данном примере работает аналогично методу View() в контроллерах

        public IViewComponentResult Invoke(bool showList)
        {
            if (showList)
            {
                return View("CityList", repository.Cities);
            }
            else return View(new CityViewModel
            {
                Cities = repository.Cities.Count(),
                Populaton = repository.Cities.Sum(c => c.Population)
            }); ;
        }
        #endregion

        #region Передача строки 
        //Здесь строка, переданная в метод Content() кодируется, благодарячему браузер не интерпретирует теги в строке как html-разметку
        /*public IViewComponentResult Invoke()
        {
            return Content("This is a <h3><i>string<i><h3>");
        }*/
        #endregion

        #region Включение фрагментов HTML в родительское представление
        /* public IViewComponentResult Invoke() =>
             new HtmlContentViewComponentResult(
                 new HtmlString("This is a <h3><i>string<i><h3>"));*/
        #endregion
    }
}
