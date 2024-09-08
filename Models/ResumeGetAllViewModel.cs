using Services.SkillGroup;
using Services.SkillType;

namespace WebUI.Models
{
    public class ResumeGetAllViewModel
    {
        public IEnumerable<SkillTypeGetAll> SkillTypes { get; set; }
        public IEnumerable<SkillGroupGetAll> SkillGroups { get; set; }
    }
}
