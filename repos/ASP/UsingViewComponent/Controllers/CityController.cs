using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using UsingViewComponent.Models;



namespace UsingViewComponent.Controllers
{
    [ViewComponent(Name ="ComboComponent")]
    public class CityController : Controller
    {
        private ICityRepository repository;

        public CityController(ICityRepository repo)
        {
            repository = repo;
        }
     
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(City newCity)
        {
            repository.AddCity(newCity);
            return RedirectToAction("Index","Home");
        }

        public IViewComponentResult Invoke() =>
            new ViewViewComponentResult()
            {
                ViewData = new ViewDataDictionary<IEnumerable<City>>(ViewData, repository.Cities)
            };
    }
}
