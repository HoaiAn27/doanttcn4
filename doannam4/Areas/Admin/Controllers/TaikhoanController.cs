using doannam4.Models;
using doannam4.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace doannam4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TaikhoanController : Controller
    {
        private readonly DataContext _context;
        public TaikhoanController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //Thêm 2 lệnh sau vào các Action của các Controller
            //Để kiểm tra trạng thại đăng nhập
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");

            var mnList = _context.AdminUsers.OrderBy(m => m.UserID).ToList();
            return View(mnList);
        }
    }
}
