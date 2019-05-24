using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScientificReport.Models;
using ScientificReportData;
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
        public IActionResult ConferencePage()
        {
            return View();
        }
        
        
        public IActionResult AddConference(string co )
        {            
            string[] arr = co.Split('*');
            string[] q = arr[2].Split('-');
            DateTime date = new DateTime(int.Parse(q[0]), int.Parse(q[1]), int.Parse(q[2]));
            Conference newConf = new Conference()
            {
                Title =arr[0],
                Description=arr[1],
                Date=date,
                ImgPath =arr[3],
                Likes=0,
                Watches=0               
                
            };
            conferenceService.Add(newConf);
            var conferences = conferenceService.getAll();
            var result = conferences
                .Select(r => new Conference()
                {
                    Id = r.Id,
                    Date = r.Date,
                    Description = r.Description,
                    ImgPath = r.ImgPath,
                    Likes = r.Likes,
                    Title = r.Title,
                    Watches = r.Watches
                });
            return View("Index", result);
        }
        public IActionResult SaveConference()
        {
            return Ok();
        }

        public IActionResult AddToUserConference(int id, string userId)
        {
            var conferenceUsers = userConferenceService.getAll();
            bool tookPart = false;
            foreach (var item in conferenceUsers)
            {
                if (item.ConferenceId == id && item.UserId == userId)
                {
                    tookPart = true;
                }
            }
            ConferenceDetailsModel model = new ConferenceDetailsModel();
            model.TakePart = false;
            UserConference element = new UserConference()
            {
                ConferenceId = id,
                UserId = userId
            };
            model.TakePart = tookPart;
            if (!model.TakePart)
            {
                userConferenceService.Add(element);
                conferenceUsers = userConferenceService.getAll();
            }

            var thisConferenceUsers = conferenceUsers
                .Where(res => res.ConferenceId == id)
                .Select(res => res.UserId);
            var thisConferenceUserNames = from i in thisConferenceUsers select userService.getById(i).Name;
            model.UserNames = thisConferenceUserNames;
            foreach (var item in conferenceUsers)
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
            var conferenceUsers = userConferenceService.getAll();
            ConferenceDetailsModel model = new ConferenceDetailsModel();
            model.TakePart = false;
            foreach (var item in conferenceUsers)
            {
                if (item.ConferenceId == id && item.UserId == userId)
                {
                    model.TakePart = true;
                }
            }
           
            
            var thisConferenceUsers = conferenceUsers
                .Where(res => res.ConferenceId == id)
                .Select(res => res.UserId);
            var thisConferenceUserNames = from i in thisConferenceUsers select userService.getById(i).Name;
            model.UserNames = thisConferenceUserNames;

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
        public IActionResult DeleteUserFromConference(int id,string userId)
        {
            var conferenceUsers = userConferenceService.getAll();
            
            var ConferenceUsers = conferenceUsers
                .Where(res => res.ConferenceId == id)
                .Select(res => res);
            var userToDel =( from i in ConferenceUsers where i.UserId==userId select i ).ToList();

            userConferenceService.Delete(userToDel[0]);
            ConferenceDetailsModel model = new ConferenceDetailsModel();
            
            model.TakePart = false;
            

            conferenceUsers = userConferenceService.getAll();
            var thisConferenceUsers = conferenceUsers
                .Where(res => res.ConferenceId == id)
                .Select(res => res.UserId);
            var thisConferenceUserNames = from i in thisConferenceUsers select userService.getById(i).Name;
            model.UserNames = thisConferenceUserNames;

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
            return View("Details",model);
        }
    }
}
