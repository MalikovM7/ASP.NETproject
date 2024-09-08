using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    public class PersonSkillsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
