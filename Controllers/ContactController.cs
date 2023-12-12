using doannam4.Models;
using doannam4.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace doannam4.Controllers
{
    public class ContactController : Controller
    {
        private readonly DataContext _context;
        public ContactController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
    }
}
