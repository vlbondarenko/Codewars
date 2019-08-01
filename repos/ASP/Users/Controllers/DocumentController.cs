using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Users.Models;


namespace Users.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {
        private ProtectedDocument[] docs = new ProtectedDocument[]
        {
          new ProtectedDocument{Title="Q3 Budget",Author="Alice",Editor="Joe"},
          new ProtectedDocument{Title="Project Plan",Author="Bob",Editor="Alice"}
        };
        private IAuthorizationService authorizationService;
        public DocumentController(IAuthorizationService service)
        {
            authorizationService = service;
        }

        public ViewResult Index() => View(docs);



        public async Task<IActionResult> Edit(string title)
        {
            ProtectedDocument doc = docs.FirstOrDefault(d => d.Title == title);
            AuthorizationResult authorization = await authorizationService.AuthorizeAsync(User, doc, "AuthorsAndEditors");
            if (authorization.Succeeded)
                return View("Index", doc);
            else
                return new ChallengeResult();
        }
    }
}
