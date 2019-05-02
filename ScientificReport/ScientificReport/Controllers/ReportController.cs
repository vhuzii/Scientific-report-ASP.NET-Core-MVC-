using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Rotativa.AspNetCore;
using ScientificReportData.Models;
using ScientificReportServices;

namespace ScientificReport.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly UserManager<User> _userManager;

		public ReportController(IReportService reportService, IUserService userService, UserManager<User> userManager)
        {
            this._reportService = reportService;
            this._userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
	        var currentUser = await _userManager.GetUserAsync(User);
			return View(currentUser);
        }

        public async Task<IActionResult> CreateReportAsync()
        {
			var currentUser = await _userManager.GetUserAsync(User);
			var report = _reportService.CreateReport(currentUser);

			return new ViewAsPdf("CreateReport", report) { FileName = "Report.pdf" };
		}
    }
}
