using Microsoft.AspNetCore.Mvc;

namespace MVC_1.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Blog()
        {
            return View();
        }
    }
}
