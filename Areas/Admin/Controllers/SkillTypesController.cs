using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    public class SkillTypesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
