using doannam4.Models;
using Microsoft.AspNetCore.Mvc;

namespace doannam4.Components
{
    [ViewComponent(Name = "Phobien")]
    public class PhobienComponent : ViewComponent
    {
        private readonly DataContext _context;

        public PhobienComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = (from p in _context.PostAccesses
                              where (p.IsActive == true) && (p.Status == 1)
                              orderby p.AccessCount descending
                              select p).Take(5).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }
    }
}
