using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SportStore.Models;
using SportStore.Models.ViewModels;
using SportStore.Infrastructure;


namespace SportStore.Controllers
{
    public class CartController:Controller
    {
        private IProductRepository productRepository;
        private Cart cart;
        public CartController(IProductRepository repo,Cart cartService)
        {
            productRepository = repo;
            cart = cartService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }

        public RedirectToActionResult AddToCard(int productID, string returnUrl, int quantity)
        {
            Product product = productRepository.Products.FirstOrDefault(p=>p.ProductID==productID);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int ProductID,string returnUrl)
        {
            Product product = productRepository.Products.FirstOrDefault(p => p.ProductID == ProductID);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

    }
}
