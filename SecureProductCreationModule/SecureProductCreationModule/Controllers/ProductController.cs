using Microsoft.AspNetCore.Mvc;
using SecureProductCreationModule.DataAccessFactory;
using SecureProductCreationModule.Entities;

namespace SecureProductCreationModule.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext _context;

        public ProductController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,Description")]Product product)
        {
            if(ModelState.IsValid)
            {
                if (_context.Products.FirstOrDefault(m => m.Name == product.Name) == null)
                {
                    product.CreatedDate = DateTime.Now;
                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMsg"] = "Product created successfully!";

                    return RedirectToAction("Create");
                }
                TempData["ErrorMsg"] = "This product is already exist!";
            }
            return View(product);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
