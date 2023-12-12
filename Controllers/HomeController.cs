using doannam4.Models;
using doannam4.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using X.PagedList;

namespace doannam4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        /*Action Detail*/

        [Route("/post-{slug}-{id:long}.html", Name = "Details")]
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = _context.Posts
                .FirstOrDefault(m => m.PostID == id && m.IsActive == true);

            if (post == null)
            {
                return NotFound();
            }
            /*lượt truy cập*/
            var accessCount = _context.PostAccessCounts.FirstOrDefault(pac => pac.PostID == post.PostID);

            if (accessCount != null)
            {
                accessCount.AccessCount++;
            }
            else
            {
                accessCount = new PostAccessCount
                {
                    PostID = post.PostID,
                    AccessCount = 1
                };
                _context.PostAccessCounts.Add(accessCount);
            }

            _context.SaveChanges();

            ViewData["AccessCount"] = accessCount != null ? accessCount.AccessCount : 0;
            
            Functions._PostID = post.PostID;
            return View(post);
        }

        /*Action Dangky*/
        [HttpPost]
        public IActionResult Dangky(Dangky dangky)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dangky);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }


        /*Action list*/
        [Route("/list-{slug}-{id:int}.html", Name = "List")]
        public IActionResult List(int? id, int? page)
        {
            if (id == 1)
            {
                return RedirectToAction("Index", "Home");
            }    
            if (id == 17)
            {
                return RedirectToAction("Index", "Contact");
            }
            if (id == null)
            {
                return NotFound();
            }

            var list = _context.PostMenus
                .Where(m => (m.MenuID == id) && (m.IsActive == true))
                .ToList();

            if (list == null)
            {
                return NotFound();
            }
            //phân trang
            int pageSize = 7;
            int pageNumber = (page ?? 1); // Sử dụng giá trị trang hiện tại hoặc mặc định là 1

            var pagedList = list.ToPagedList(pageNumber, pageSize);

            ViewBag.id = id;
            return View(pagedList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}