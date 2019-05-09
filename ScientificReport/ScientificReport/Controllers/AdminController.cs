using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScientificReport.Models;
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
        public IActionResult Index()
        {
            var users = userService.getAll();
            var models = users
                .Select(result => new UserModel
                {
                    Id = result.Id,
                    FullName = result.Name,
                    Role = result.Role.ToString(),
                    Status = result.IsApproved
                });
            var modelApproved = from i in models where i.Status == true select i;
            var modelnotApproved = from i in models where i.Status == false select i;
            KeyValuePair<IEnumerable<UserModel>, IEnumerable<UserModel>> model = new KeyValuePair<IEnumerable<UserModel>, IEnumerable<UserModel>>(modelApproved, modelnotApproved);
            return View();
        }
    }
}
