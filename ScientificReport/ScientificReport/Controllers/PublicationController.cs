using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScientificReport.Models;
using ScientificReportData;
using ScientificReportData.Enums;
using ScientificReportData.Models;
using ScientificReportServices.Interfaces;

namespace ScientificReport.Controllers
{
    public class PublicationController : Controller
    {
        private readonly IPublicationService _pubServ;
        public PublicationController( IPublicationService pubServ)
        {
            _pubServ = pubServ;
        }



        [HttpPost]
        public IActionResult SavePublication([FromForm]CreatePublicationModel model)
        {
            _pubServ.AddPublication(model);

            return RedirectToAction("Create");
        }
    }
}
