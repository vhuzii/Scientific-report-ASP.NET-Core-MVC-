using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScientificReport.Models;
using ScientificReportData.Models;
using ScientificReportServices;
using ScientificReportServices.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScientificReport.Controllers
{
    public class ConferencesController : Controller
    {
        private readonly IConferenceService conferenceService;
        private readonly IUserService userService;
        private readonly IUserConferenceService userConferenceService;
       
        public ConferencesController(IConferenceService conferenceService,IUserService userService,IUserConferenceService userConferenceService)
        {
            this.conferenceService = conferenceService;
            this.userService = userService;
            this.userConferenceService = userConferenceService;
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

        public IActionResult SaveConference()
        {
            return Ok();
        }

        public IActionResult AddToUserConference(int id, string userId)
        {
            var thisConferenceUsers = userConferenceService.getAll();
            ConferenceDetailsModel model = new ConferenceDetailsModel();
            model.TakePart = false;
            UserConference element = new UserConference()
            {
                ConferenceId = id,
                UserId = userId
            };
            userConferenceService.Add(element);
            thisConferenceUsers = userConferenceService.getAll();
            foreach (var item in thisConferenceUsers)
            {
                if(item.ConferenceId==id&&item.UserId==userId)
                {
                    model.TakePart = true;
                }
            }
            var result = conferenceService.getById(id);
            var data = new Conference()
            {
                Id = result.Id,
                Date = result.Date,
                Description = result.Description,
                ImgPath = result.ImgPath,
                Likes = result.Likes,
                Title = result.Title,
                Watches = result.Watches
            };
           
            model.ConferenceInfo = data;
          
            return View("Details",model);
        }

        public IActionResult Details(int id,string userId)
        {
            var thisConferenceUsers = userConferenceService.getAll();
            ConferenceDetailsModel model = new ConferenceDetailsModel();
            model.TakePart = false;
            foreach (var item in thisConferenceUsers)
            {
                if (item.ConferenceId == id && item.UserId == userId)
                {
                    model.TakePart = true;
                }
            }
            var result = conferenceService.getById(id);
            result.Watches = result.Watches + 1;
            conferenceService.Update(result);
            var data = new Conference()
            {
                Id = result.Id,
                Date = result.Date,
                Description = result.Description,
                ImgPath = result.ImgPath,
                Likes = result.Likes,
                Title = result.Title,
                Watches = result.Watches
            };
            model.ConferenceInfo = data;
            return View(model);
        }
    }
}
