using doannam4.Models;
using Microsoft.AspNetCore.Mvc;

namespace doannam4.Controllers
{
    public class SearchController : Controller
    {
        private readonly DataContext _context;
        public SearchController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchTerm)
        {
            if (searchTerm == null)
            {
                return NotFound();
            }
            var searchResults = _context.Posts
                 .Where(p => p.Title.Contains(searchTerm) || p.Contents.Contains(searchTerm))
                 .ToList();
            if (searchResults == null)
            {
                return NotFound();
            }
            return View(searchResults);
        }

    }
}
