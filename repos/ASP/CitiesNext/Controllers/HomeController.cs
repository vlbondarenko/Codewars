using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cities.Models;



namespace Cities.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;

        public HomeController(IRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() =>
            View(repository.Cities);

        public ViewResult Edit() =>
            View("Create", repository.Cities.First());

        public ViewResult Create() =>
            View();

        [HttpPost]
        /*Атрибут ValidateAntoForgeryToken гарантирует, что запрос содержит допустимые маркеры 
         * противодействия атакам CSRF. и будет генерировать исключение, если 
         * они отсутствуют или не имеют ожидаемые значения. */
        [ValidateAntiForgeryToken]  
        public IActionResult Create(City city)
        {
            repository.AddCity(city);
            return RedirectToAction("Index");
        }
    }
}
