using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JapanCandyBoxEShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScientificReport.Controllers
{
    public class AdminController : Controller
    {
        // GET: /<controller>/
        private UserManager<IdentityUser> _userManager;

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SendMessage(string value)
        {
            string[] arr = value.Split('*');
            string subject = arr[0]; string text = arr[1];
            Email emailService = new Email();
            foreach (var i in _userManager.Users.ToList())
            {
                await emailService.SendEmailAsync(i.Email, subject, text);
            }

            return RedirectToAction("Index");
        }

    }
}
