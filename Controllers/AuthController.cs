using Application.Dto;
using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Services.Common;

namespace MVC_1.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _service;
        private readonly IEmailService _emailService;

        public AuthController(IUserService service , IEmailService emailService)
        {
            _emailService = emailService;
            _service = service;
        }


        public async Task<IActionResult> Index()
        {

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(LoginDto model)
        {
            var user = await _service.Login(model);

            return RedirectToAction("Index", "Home");


        }

        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                var user = await _service.Register(model);

                await _emailService.Send("malikvm@code.edu.az", model.Email, "Welcome to Our Service");

                TempData["message"] = "Registration successful! A confirmation email has been sent.";
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Auth");
        }

    }
}
