using Microsoft.AspNetCore.Mvc;
using Northwind.DataContext.SqlServer; 
using Northwind.EntityModels;
using System.Linq;

namespace NorthwindMvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly NorthwindDatabaseContext _context;

        public CategoryController(NorthwindDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Details(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
    }
}

