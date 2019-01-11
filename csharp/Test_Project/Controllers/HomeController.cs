using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Test_Project.Models;

namespace Test_Project.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewModel AuthorView = new ViewModel();
            return View(AuthorView);
        }

        [HttpPost("authors")]
        //  the parameter name must match the name in the model(or viewmodel) lowercase
        public IActionResult Create(Author author)
        {
            if(ModelState.IsValid) {
                Console.WriteLine($"------------------------ Author name is: {author.Name} -------------------------");
                Console.WriteLine(author.Name);
                return RedirectToAction("Index");
            } else {
                ViewModel AuthorView = new ViewModel();
                AuthorView.Author = author;
                return View("Index", AuthorView);
            }
        }
    }
}
