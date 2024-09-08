using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    public class SkillGroupsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
