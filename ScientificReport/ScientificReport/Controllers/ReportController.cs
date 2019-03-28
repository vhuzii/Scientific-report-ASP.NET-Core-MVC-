using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ScientificReport.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}