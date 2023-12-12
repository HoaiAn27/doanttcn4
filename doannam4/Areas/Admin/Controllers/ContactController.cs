using doannam4.Models;
using doannam4.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace doannam4.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly DataContext _context;
        public ContactController(DataContext context)
        {
            _context = context;
        }

        /* Index*/
        public IActionResult Index()
        {

            //Thêm 2 lệnh sau vào các Action của các Controller
            //Để kiểm tra trạng thại đăng nhập
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");

            var mnList = _context.Contacts.OrderBy(m => m.ContactID).ToList();
            return View(mnList);
        }

        /*Xoá*/
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Contacts.Find(id);

            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            var deleContact = _context.Contacts.Find(id);
            if (deleContact == null)
            {
                return NotFound();
            }
            _context.Contacts.Remove(deleContact);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
