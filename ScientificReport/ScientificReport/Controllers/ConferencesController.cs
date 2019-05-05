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
        private readonly IConferenceService conferenceService;
       
        public ConferencesController(IConferenceService conferenceService)
        {
            this.conferenceService = conferenceService;            
        }

        public IActionResult Index()
        {
            var conferences = conferenceService.getAll();
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
            var result = conferenceService.getById(id);
            result.Watches = result.Watches + 1;
            conferenceService.Update(result);
            var model = new Conference()
            {
                Id = result.Id,
                Date = result.Date,
                Description = result.Description,
                ImgPath = result.ImgPath,
                Likes = result.Likes,
                Title = result.Title,
                Watches = result.Watches
            };
            return View();
        }
    }
}
