using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Models;
using DependencyInjection.Infrastructure;

namespace DependencyInjection.Controllers
{
    public class HomeController:Controller
    {

        #region Создание слабо связанного компонента с применением средств ASP.NET

        private IRepository repository;         //переменная для доступа к временному репозиторию
        private ProductTotalizer totalizer;
        //в конструктор контроллера передается объект релизующий интерфейс IRepository - это и есть 
        //слабо связанныq компонент, т.к. контроллеру ничего не известно о передаваемом объекте и как 
        //реализован репозиторий.
        //Как это работает:
        //  1) Инфраструктура MVC получает входящий запрос к методу действия контроллера
        //  2) Инфраструктура MVC требует у компонента поставщика служб ASP.Net (компонента, который отвечает
        //     за отображение интерфейсов на типы реализации) новый экземпляр класса HomeController
        //  3) Поставщик служб инспектирует конструктор HomeController и обнаруживает, 
        //     что он имеет зависимость от интерфейса IRepository. 
        //  4) Поставщик служб обращается к своим отображениям, чтобы найти класс реализации, 
        //     который подлежит применению для зависимостей от интерфейса IRepository. 
        //  5) Поставщик служб создает новый экземпляр найденного класса реализации. 
        //  6) Поставщик служб создает новый объект HomeController, используя объект 
        //     реализации в качестве аргумента конструктора.
        //  7) Поставщик служб возвращает созданный объект HomeController инфраструктуре MVC, 
        //     который она применяет для обработки входящего НТТР-запроса. 
        public HomeController(IRepository repo,ProductTotalizer totalizer)
        {
            repository = repo;
            this.totalizer = totalizer;
        }

        public ViewResult Index()
        {
            ViewBag.Total = totalizer.Total;
            ViewBag.GuidOfHomecontroller = repository.ToString();
            ViewBag.GuidOfTotalizer = totalizer.Repository.ToString();
            return View(repository.Products);
        }

        #endregion

        #region Внедрение зависимости в действие

        //Здесь объект создается посредсвом поставщика служб только при обращеннии к данному методу действия
        //В этом главное отличие от получения объекта через конструктор
        /*public ViewResult Index([FromServices]ProductTotalizer total)
        {
            ViewBag.Homecontroller = repository.ToString();
            ViewBag.Totalizer = total.Repository.ToString();
            return View(repository.Products);
        }*/

        #endregion

        #region Создание сильно связанного компонента

        //Создание сильно связанного компонента. Здесь контроллер и конкретный класс репозитория связываются 
        //образуяединый модулю, который трудно тестировать
        /*public ViewResult Index() =>
            View(new MemoryRepository().Products);*/

        #endregion

        #region Создание слабо связанного компонента с применением класса TypeBroker

        //Получение объекта репозитория через класс TypeBroker. По умолчанию это объект типа MemoryRepositiry
        /* public IRepository Repository => TypeBroker.Repository;

         public ViewResult Index() =>
             View(Repository.Products);*/

        #endregion
    }
}
