using Microsoft.AspNetCore.Mvc;
using Services.SkillGroup;
using Services.SkillType;
using WebUI.Models;

namespace MVC_1.Controllers
{
    public class ResumeController : Controller
    {
        private readonly ISkillTypeService skillTypeService;
        private readonly ISkillGroupService skillGroupService;

        public ResumeController(ISkillTypeService skillTypeService,
                                ISkillGroupService skillGroupService)
        {
            this.skillTypeService = skillTypeService;
            this.skillGroupService = skillGroupService;
        }
        public async Task<IActionResult> Index()
        {
            var skillTypes = await skillTypeService.GetAllAsync();
            var skillGroups = await skillGroupService.GetAllAsync();

            var vm = new ResumeGetAllViewModel
            {
                SkillGroups = skillGroups,
                SkillTypes = skillTypes
            };

            return View(vm);
        }
    }
}
