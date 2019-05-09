using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScientificReport.Models;
using ScientificReportData.Models;
using ScientificReportServices;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScientificReport.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService userService;
        
        public  AdminController(IUserService UserService)
        {
            this.userService = UserService;
        }

        public IActionResult Admin()
        {
            var users = userService.getAll();
            var models = users
                .Select(result => new UserModel
                {
                    Id = result.Id,
                    FullName = result.Name,
                    Faculty = result.Faculty,
                    Department = result.Department,
                    Status = result.IsApproved
                });
            var modelApproved = from i in models where i.Status == true select i;
            var modelnotApproved = from i in models where i.Status == false select i;
            KeyValuePair<IEnumerable<UserModel>, IEnumerable<UserModel>> model = new KeyValuePair<IEnumerable<UserModel>, IEnumerable<UserModel>>(modelApproved, modelnotApproved);
            return View("Index", model);
        }
        public IActionResult DepartmentAdmin(string id)
        {
            var users = userService.getAll();
            var models = users
                .Select(result => new UserModel
                {
                    Id = result.Id,
                    FullName = result.Name,
                    Faculty = result.Faculty,
                    Department = result.Department,
                    Status = result.IsApproved
                });
            models = from i in models where i.Department == userService.getById(id).Department select i;
            var modelApproved = from i in models where i.Status == true select i;
            var modelnotApproved = from i in models where i.Status == false select i;
            KeyValuePair<IEnumerable<UserModel>, IEnumerable<UserModel>> model = new KeyValuePair<IEnumerable<UserModel>, IEnumerable<UserModel>>(modelApproved, modelnotApproved);
            return View("Index", model);
        }
        public IActionResult FacultyAdmin(string id)
        {
            var users = userService.getAll();
            var models = users
                .Select(result => new UserModel
                {
                    Id = result.Id,
                    FullName = result.Name,
                    Faculty = result.Faculty,
                    Department = result.Department,
                    Status = result.IsApproved
                });
            models = from i in models where i.Faculty == userService.getById(id).Faculty select i;
            var modelApproved = from i in models where i.Status == true select i;
            var modelnotApproved = from i in models where i.Status == false select i;
            KeyValuePair<IEnumerable<UserModel>, IEnumerable<UserModel>> model = new KeyValuePair<IEnumerable<UserModel>, IEnumerable<UserModel>>(modelApproved, modelnotApproved);
            return View("Index", model);
        }
        public async void SendMessage(string userEmail, string theme, string messageS)
        {
            Email emailService = new Email();

            await emailService.SendEmailAsync(userEmail, theme, messageS);

        }
        public IActionResult Approve(string id)
        {
            User user = userService.getById(id);
            user.IsApproved = true;
            userService.Update(user);
            var users = userService.getAll();
            string theme = "Your account at АUТО_ЗВІТ was successfully approved!!!";
            string messageS = "Dear, "+ user.Name + "! Your account at АUТО_ЗВІТ was successfully approved!" +
                " To start working with our service, just login into system and ENJOY!";
            
            SendMessage(user.Email, theme, messageS);
            
            var models = users
                .Select(result => new UserModel
                {
                    Id = result.Id,
                    FullName = result.Name,
                    Faculty = result.Faculty,
                    Department = result.Department,
                    Status = result.IsApproved
                });
            var modelApproved = from i in models where i.Status == true select i;
            var modelnotApproved = from i in models where i.Status == false select i;
            KeyValuePair<IEnumerable<UserModel>, IEnumerable<UserModel>> model = new KeyValuePair<IEnumerable<UserModel>, IEnumerable<UserModel>>(modelApproved, modelnotApproved);
            return View("Index", model);
        }

        
    }
}
