using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScientificReportData.Models;
using ScientificReportServices;
using ScientificReportServices.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScientificReport.Controllers
{
    public class InfoController : Controller
    {
        // GET: /<controller>/
        private readonly IReportItemsService _serv;

        public InfoController(IReportItemsService serv)
        {
            _serv = serv;
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult DepartmentWorkForm()
        {
            return View();
        }

        [HttpPost("SaveDepartmentWork")]
        public IActionResult SaveDepartmentWork([FromForm]DepartmentWork model)
        {
            _serv.AddDepartmentWork(model);

            return RedirectToAction("Create");
        }

        public IActionResult GrantsForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveGrant([FromForm]Grant model)
        {
            _serv.AddGrant(model);

            return RedirectToAction("Create");
        }

        public IActionResult PublicationForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SavePublication([FromForm]Publication model)
        {
            _serv.AddPublication(model);

            return RedirectToAction("Create");
        }
    }
}
