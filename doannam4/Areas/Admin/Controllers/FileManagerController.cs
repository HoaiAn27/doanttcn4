using doannam4.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace doannam4.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/file-manager")]
    public class FileManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
