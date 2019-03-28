using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScientificReport.Models;

namespace ScientificReport.Controllers
{
    public class PublicationController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
