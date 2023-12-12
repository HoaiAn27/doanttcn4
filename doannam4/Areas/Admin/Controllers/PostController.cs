using doannam4.Models;
using doannam4.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace doannam4.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly DataContext _context;
        public PostController(DataContext context)
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

            var mnList = _context.Posts.OrderBy(m => m.MenuID).ToList();
            return View(mnList);
        }

        /*Create*/
        public IActionResult Create()
        {
            var mnList = (from m in _context.Menus
                          where (m.Levels == 2) || (m.Levels == 1)
                          select new SelectListItem()
                          {
                              Text = m.MenuName,
                              Value = m.MenuID.ToString()
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            ViewBag.mnList = mnList;
            return View();
        }


        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        /*Xoá*/
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Posts.Find(id);

            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            var delePost = _context.Posts.Find(id);
            if (delePost == null)
            {
                return NotFound();
            }
            _context.Posts.Remove(delePost);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        /*Sửa*/
        public IActionResult Edit(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Posts.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            var mnList = (from m in _context.Posts
                          select new SelectListItem()
                          {
                              Text = m.Abstract,
                              Value = m.PostID.ToString(),
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            ViewBag.mnList = mnList;
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Post mn)
        {
            if (ModelState.IsValid)
            {
                _context.Posts.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
    }
}
