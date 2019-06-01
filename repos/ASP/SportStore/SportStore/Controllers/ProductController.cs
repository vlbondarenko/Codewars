using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Models.ViewModels;

namespace SportStore.Controllers
{
    public class ProductController:Controller
    {
        IProductRepository repository;

        public  int PageSize = 4;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public IActionResult List(string category, int page=1) => View(
            new ProductListViewPage {
                Products = repository.Products.Where(p=>category==null||p.Category==category)
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo {
                    CurrentPage = page, ItemPerPage = PageSize,
                    TotalItem =category==null?repository.Products.Count():repository.Products.Where(e=>e.Category==category).Count()
                },
                CurrentCategory = category
            });
    }
}
