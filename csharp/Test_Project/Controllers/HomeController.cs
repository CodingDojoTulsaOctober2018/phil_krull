using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Test_Project.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Test_Project.Controllers
{
    public class HomeController : Controller
    {
        private Context _context;
        public HomeController(Context context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // add in authors to session

            // List<Author> Authors = _context.Authors.ToList();
            // Console.WriteLine($"there are {Authors.Count} authors in the db");
            Console.WriteLine($"++++++++++++++++++++ Author from Index Method {TempData["author"]}++++++++++++++++++++");
            ViewModel AuthorView = new ViewModel();

            AuthorView.Allauthors = _context.Authors.ToList();
            AuthorView.Allbooks = _context.Books.Include(book => book.WrittenBy).Include(book => book.PublishedBy).ThenInclude(publishedBy => publishedBy.Publisher).ToList();
            AuthorView.Allpublishers = _context.Publishers.Include(publisher => publisher.PublishedBy).ThenInclude(publishedBy => publishedBy.Book).ToList();

            // -------------- below is the session example -----------------
            // string AuthorChecker = HttpContext.Session.GetString("AllAuthors");


            // if(AuthorChecker == null) {
            //     // Save the allAuthors in session
            //     HttpContext.Session.SetObjectAsJson("AllAuthors", AuthorView.Allauthors);
            // } else {
            //     // all authors is set already, add the added author to session
            //     // get current list of authrs from session
            //     List<Author> AllAuthors = HttpContext.Session.GetObjectFromJson<List<Author>>("AllAuthors");
            //     // add the new author to the list
            //     Author NewAuthor = new Author((string)TempData["author"]);
            //     AllAuthors.Add(NewAuthor);
            //     // save the new list in the viewmodel
            //     AuthorView.Allauthors = AllAuthors;
            //     // save the the list in session
            //     HttpContext.Session.SetObjectAsJson("AllAuthors", AllAuthors);
            // }
            // -------------- end of session example -----------------




            return View(AuthorView);
        }

        [HttpPost("authors")]
        //  the parameter name must match the name in the model(or viewmodel) lowercase
        public IActionResult Create(Author author)
        {
            if(ModelState.IsValid) {
                Console.WriteLine($"------------------------ Author name is: {author.Name} -------------------------");
                Console.WriteLine(author.Name);
                // used tempdata for session
                // TempData["author"] = author.Name;
                // save author in db
                _context.Authors.Add(author);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else {
                ViewModel AuthorView = new ViewModel();
                AuthorView.Author = author;
                AuthorView.Allauthors = _context.Authors.ToList();
                AuthorView.Allbooks = _context.Books.Include(book => book.WrittenBy).ToList();
                AuthorView.Allpublishers = _context.Publishers.ToList();
                return View("Index", AuthorView);
            }
        }

        [HttpPost("authors/{authorId}")]
        public IActionResult Delete(long authorId)
        {
            Author Author = _context.Authors.FirstOrDefault(author => author.AuthorId == authorId);
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine(Author.Name);
            _context.Authors.Remove(Author);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost("books")]
        public IActionResult CreateBook(Book book)
        {
            if(ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else {
                ViewModel AuthorView = new ViewModel();
                AuthorView.Book = book;
                AuthorView.Allauthors = _context.Authors.ToList();
                AuthorView.Allbooks = _context.Books.Include(b => b.WrittenBy).ToList();
                return View("Index", AuthorView);
            }
        }

        [HttpPost("publishers")]
        public IActionResult CreatePublisher(Publisher publisher)
        {
            if(ModelState.IsValid)
            {
                _context.Publishers.Add(publisher);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else {
                ViewModel AuthorView = new ViewModel();
                AuthorView.Publisher = publisher;
                AuthorView.Allauthors = _context.Authors.ToList();
                AuthorView.Allbooks = _context.Books.Include(book => book.WrittenBy).ToList();
                AuthorView.Allpublishers = _context.Publishers.ToList();
                return View("Index", AuthorView);
            }
        }

        [HttpPost("book_need_publisher")]
        public IActionResult AddBookToPublisher(PublishedBy publishedBy)
        {
            if(ModelState.IsValid)
            {
                Console.WriteLine(publishedBy.BookId);
                Console.WriteLine(publishedBy.PublisherId);
                _context.PublishedBook.Add(publishedBy);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else {
                ViewModel AuthorView = new ViewModel();
                AuthorView.PublishedBy = publishedBy;
                AuthorView.Allauthors = _context.Authors.ToList();
                AuthorView.Allbooks = _context.Books.Include(book => book.WrittenBy).ToList();
                AuthorView.Allpublishers = _context.Publishers.ToList();
                return View("Index", AuthorView);
            }
        }
    }
}
