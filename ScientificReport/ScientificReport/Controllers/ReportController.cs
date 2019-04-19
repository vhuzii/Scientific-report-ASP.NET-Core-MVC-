using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IUserService _userService;

        public ReportController(IReportService reportService, IUserService userService)
        {
            _reportService = reportService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateReport()
        {
            var currentUser = _userService.CurrentUser;
            var report = _reportService.CreateReport(currentUser);

			return new ViewAsPdf("CreateReport", report) { FileName = "Report.pdf" };
		}
    }
}
