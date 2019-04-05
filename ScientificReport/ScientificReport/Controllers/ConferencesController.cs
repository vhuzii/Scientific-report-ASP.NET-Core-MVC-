using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScientificReportData.Models;
using ScientificReportServices;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScientificReport.Controllers
{
    public class ConferencesController : Controller
    {
        static private IConference _assets;
       
        public ConferencesController(IConference assets)
        {
            _assets = assets;            
        }

        public IActionResult Index()
        {
            var conferences = _assets.getAll();
            var result = conferences
                .Select(r => new Conference()
                {
                    Id = r.Id,
                   Date = r.Date,
                   Description = r.Description,
                   ImgPath = r.ImgPath,
                   Likes=r.Likes,
                   Title=r.Title,
                   Watches = r.Watches
                });
            return View(result);
        }
        public IActionResult Details(int id)
        {
            var r = _assets.getById(id);
            var model = new Conference()
            {
                Id = r.Id,
                Date = r.Date,
                Description = r.Description,
                ImgPath = r.ImgPath,
                Likes = r.Likes,
                Title = r.Title,
                Watches = r.Watches
            };
            return View(model);
        }
    }
}
