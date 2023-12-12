using doannam4.Models;
using Microsoft.AspNetCore.Mvc;

namespace doannam4.Components
{
    [ViewComponent(Name = "Comment")]
    public class CommentComponent : ViewComponent
    {
        private DataContext _context;
        public CommentComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = (from p in _context.Comments
                              where (p.IsActive == true)
                              orderby p.CommentID descending
                              select p).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }
    }
}