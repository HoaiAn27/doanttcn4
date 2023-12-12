using doannam4.Models;
using doannam4.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace doannam4.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly DataContext _context;
        public CommentController(DataContext context)
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

            var mnList = _context.Comments.OrderBy(m => m.CommentID).ToList();
            return View(mnList);
        }

        /*Xoá*/
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Comments.Find(id);

            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            var deleComment = _context.Comments.Find(id);
            if (deleComment == null)
            {
                return NotFound();
            }
            _context.Comments.Remove(deleComment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
