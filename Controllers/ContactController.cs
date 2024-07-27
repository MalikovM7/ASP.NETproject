using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC_1.Controllers
{

    public class ContactController : Controller
    {

        private readonly IContactPostService _contactPostService;

        public ContactController(IContactPostService contactPostService)
        {
            _contactPostService = contactPostService;
        }

        [HttpPost]
        public async Task<IActionResult> SendContactPost([FromBody] ContactPost contactPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _contactPostService.SendContactPostAsync(contactPost);

            return Ok();
        }

            public IActionResult Index()
            {
                return View();
            }
        
    }
}
