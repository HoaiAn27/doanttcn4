using doannam4.Models;
using doannam4.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dacn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //Thêm 2 lệnh sau vào các Action của các Controller
            //Để kiểm tra trạng thại đăng nhập
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");

            var mnList = _context.PostAccesses.OrderByDescending(m => m.AccessCount).ToList();
            return View(mnList);
        }
        public IActionResult Logout()
        {
            Functions._UserID = 0;
            Functions._UserName = string.Empty;
            Functions._Email = string.Empty;
            Functions._Message = string.Empty;
            Functions._MessageEmail = string.Empty;
            return RedirectToAction("Index", "Home");
        }
        public IActionResult lienhe()
        {
            return View();
        }
        public IActionResult trangcanhan()
        {
            return View();
        }
        public IActionResult help()
        {
            return View();
        }
    }
}
