using Services.Services;
using Services.Skills;


namespace WebUI.Models
{
    public class HomeGetAllViewModel
    {
        public IEnumerable<SkillGetAll> Skills { get; set; }
        public IEnumerable<ServiceGetAll> Services { get; set; }
    }
}
