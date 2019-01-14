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
            // add in authors to session

            Console.WriteLine($"++++++++++++++++++++ Author from Index Method {TempData["author"]}++++++++++++++++++++");
            ViewModel AuthorView = new ViewModel();

            string AuthorChecker = HttpContext.Session.GetString("AllAuthors");

            if(AuthorChecker == null) {
                // Save the allAuthors in session
                HttpContext.Session.SetObjectAsJson("AllAuthors", AuthorView.Allauthors);
            } else {
                // all authors is set already, add the added author to session
                // get current list of authrs from session
                List<Author> AllAuthors = HttpContext.Session.GetObjectFromJson<List<Author>>("AllAuthors");
                // add the new author to the list
                Author NewAuthor = new Author((string)TempData["author"]);
                AllAuthors.Add(NewAuthor);
                // save the new list in the viewmodel
                AuthorView.Allauthors = AllAuthors;
                // save the the list in session
                HttpContext.Session.SetObjectAsJson("AllAuthors", AllAuthors);
            }




            return View(AuthorView);
        }

        [HttpPost("authors")]
        //  the parameter name must match the name in the model(or viewmodel) lowercase
        public IActionResult Create(Author author)
        {
            if(ModelState.IsValid) {
                Console.WriteLine($"------------------------ Author name is: {author.Name} -------------------------");
                Console.WriteLine(author.Name);
                TempData["author"] = author.Name;
                return RedirectToAction("Index");
            } else {
                ViewModel AuthorView = new ViewModel();
                AuthorView.Author = author;
                return View("Index", AuthorView);
            }
        }

    }
}
