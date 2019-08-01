using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsingViewComponent.Models;


namespace UsingViewComponent.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository repository;
        public HomeController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index() =>
            View(repository.Products);

        public ViewResult Create() =>
            View();

        [HttpPost]
        public IActionResult Create(Product newProduct)
        {
            repository.AddProduct(newProduct);
            return RedirectToAction("Index");
        }
        
    }
}
