using doannam4.Models;
using doannam4.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace doannam4.Controllers
{
    public class CommentController : Controller
    {
        private readonly DataContext _context;
        public CommentController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddComment(Comment cmt)
        {
            if (ModelState.IsValid)
            {
                cmt.PostID = Functions._PostID;
                cmt.IsActive = true;
                cmt.CreateDate = DateTime.Now;
                _context.Add(cmt);
                _context.SaveChanges();

                TempData["CommentMessage"] = "Bình luận đã được gửi thành công!";

                //trả về trang hiện tại 

                long postId = cmt.PostID;
                var post = _context.Posts.FirstOrDefault(p => p.PostID == postId);
                string slug = Functions.TitleSlugGenaration("post", post.Title, postId);
                string url = $"/{slug}";

                return Redirect(url);
            }
            return RedirectToAction("Index", "home");
        }
    }
}
