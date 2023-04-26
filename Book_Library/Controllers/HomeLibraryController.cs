using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Book_Library.Data;
using Microsoft.Extensions.Logging;
using Book_Library.Models;
using Book_Library.ViewModels;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Book_Library.Controllers
{
    [Authorize]
    public class HomeLibraryController : Controller
    {
        private BookDbContext context;

        public HomeLibraryController(BookDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult HomeLibraryView()
        {
            List<Book> books = context.Book.ToList();
            return View(books);
        }

        //This retrieves the form
        [HttpGet]
        public IActionResult AddBookView()
        {
            AddBookViewModel addBookViewModel = new AddBookViewModel();
            return View(addBookViewModel);
        }

        //This processes the form
        [HttpPost]
        public IActionResult AddBookView(AddBookViewModel addBookViewModel)
        {
            if (ModelState.IsValid)
            {
                Book newBook = new Book
                {
                    BookAuthor = addBookViewModel.BookAuthorVM,
                    BookDescription = addBookViewModel.BookDescriptionVM,
                    BookGenre = addBookViewModel.BookGenreVM,
                    BookIMG = addBookViewModel.BookIMG_VM,
                    BookRating = addBookViewModel.BookRatingVM,
                    BookTitle = addBookViewModel.BookTitleVM,
                    //BookUserId = context.Users.
                };

                context.Book.Add(newBook);
                context.SaveChanges();
                return Redirect("/HomeLibrary/HomeLibraryView");
            }
            else
            {
                return View(addBookViewModel);
            }
            ;
        }
        [HttpGet]
        public IActionResult DeleteBookView()
        {
            ViewBag.book = context.Book.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult DeleteBookView(int[] bookID)
        {
            foreach (int bookId in bookID)
            {
                Book theBook = context.Book.Find(bookId);
                context.Book.Remove(theBook);
            }

            context.SaveChanges();

            return Redirect("/HomeLibrary/HomeLibraryView");
        }

        public IActionResult DetailBookView(int id)
        {
            Book theBook = context.Book.Find(id);
            return View(theBook);
        }

        //getting the data to edit 
        [HttpGet]
        public IActionResult EditBookView(int id)
        {
            Book theBook = context.Book.Find(id);
            return View(theBook);
        }

        //updating the data
        [HttpPost]
        public IActionResult EditBookView(int id, Book book)
        {
            Book theBook = context.Book.Find(id);
            if(theBook != null)
            {
                theBook.BookTitle = book.BookTitle;
                theBook.BookAuthor = book.BookAuthor;
                theBook.BookGenre = book.BookGenre;
                theBook.BookRating = book.BookRating;
                theBook.BookDescription = book.BookDescription;
                theBook.BookIMG = book.BookIMG;
                context.SaveChanges();
                return Redirect("/HomeLibrary/HomeLibraryView");
            }
            
            return View(book);
        }
    }
}

