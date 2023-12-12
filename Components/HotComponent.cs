using doannam4.Models;
using Microsoft.AspNetCore.Mvc;

namespace doannam4.Components
{
    [ViewComponent(Name = "Hot")]
    public class HotComponent : ViewComponent
    {
        private readonly DataContext _context;
        public HotComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = (from p in _context.PostMenus
                              where (p.IsActive == true) && (p.Status == 1)
                              orderby p.PostID descending
                              select p).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }
    }
}
