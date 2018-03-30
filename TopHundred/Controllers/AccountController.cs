using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TopHundred.Entities;
using TopHundred.ViewModels;

namespace TopHundred.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<Customer> _signInManager;
        private UserManager<Customer> _userManager;
        private readonly IcoListContext _context;
        public AccountController(SignInManager<Customer> signInManager, UserManager<Customer> userManager, IcoListContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated) return RedirectToAction("Index", "IcosList");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    else
                    {
                        return RedirectToAction("Index", "IcosList");
                    }
                }
            }

            ModelState.AddModelError("", "Failed to login");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
           await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "IcosList");

        }

        public async Task<IActionResult> UserAccount( Guid id)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                user.IcoItems = _context.IcoItems.Where(i => i.Customer.Id == user.Id).Take(4).ToList();

                return View(user);
            }
                

            return NotFound();
        }
    }
}
