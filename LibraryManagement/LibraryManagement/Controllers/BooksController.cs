using LibraryManagement.DataAccessLayer.Modules.Books.Interfaces;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Enums;
using LibraryManagement.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index(string? searchTerm, Genre? genre)
        {
            var books = await _repository.SearchAsync(searchTerm, genre);
            return View(books);
        }

        public async Task<IActionResult> Details(int id)
        {

            var book = await _repository.GetByIdAsync(id);
            if (book == null)
            {
                throw new BookNotFoundException(id);
            }
            return View(book);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(book);

                if (!await _repository.IsIsbnUniqueAsync(book.ISBN))
                    throw new DuplicateIsbnException(book.ISBN);

                if (book.PublicationYear > DateTime.Now.Year + 5)
                    throw new InvalidPublicationYearException(book.PublicationYear);

                book.AddedDate = DateTime.UtcNow;

                await _repository.AddAsync(book);

                TempData["Success"] = "Book created successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (DuplicateIsbnException ex)
            {
                ModelState.AddModelError("ISBN", ex.Message);
                return View(book);
            }
            catch (InvalidPublicationYearException ex)
            {
                ModelState.AddModelError("PublicationYear", ex.Message);
                return View(book);
            }
        }
    }
}
