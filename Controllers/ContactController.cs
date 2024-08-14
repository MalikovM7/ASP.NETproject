using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC_1.Controllers
{

    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(string fullname, string email, string subject, string content)
        {

            var contactPost = await _contactService.SendContactEmailAsync( fullname,  email,  subject,  content);

            return Ok(contactPost);
        }
    }
}
