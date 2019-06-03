using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScientificReport.Models;
using ScientificReportData.Models;
using ScientificReportServices;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScientificReport.Controllers
{
    public class InfoController : Controller
    {
        // GET: /<controller>/
        private readonly IReportItemsService _serv;
        private readonly UserManager<User> _userServ;

        public InfoController(IReportItemsService serv, UserManager<User> userService)
        {
            _serv = serv;
            _userServ = userService;
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> DepartmentWorkForm()
        {
	        var currentUser = await _userServ.GetUserAsync(User);
	        var availableTopics = _serv.GetPublicationIntrosByUser(currentUser);
	        ViewData["availableTopics"] = availableTopics;
			return View();
        }

        public IActionResult ReportItemFrom(string itemType)
        {
            ViewData["itemType"] = itemType;
            ViewData["shortType"] = itemType.Split(" ").Take(2).Aggregate((a, b) => a + b);
            return View();
        }

        [HttpPost("SaveDepartmentWork")]
        public async Task<IActionResult> SaveDepartmentWork([FromForm]DepartmentWork model)
        {
            var currentUser = await _userServ.GetUserAsync(User);
            var userAsAuthor = _serv.GetUserAsAuthor(currentUser.Name);
            model.Authors = new List<Author>();
            model.Authors.Add(userAsAuthor);
            model.Date = DateTime.Now;
            model.Department = currentUser.Department;
            _serv.AddDepartmentWork(model);

            return RedirectToAction("Create");
        }

        public IActionResult GrantsForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveGrant([FromForm]Grant model)
        {
            var currentUser = await _userServ.GetUserAsync(User);
            var userAsAuthor = _serv.GetUserAsAuthor(currentUser.Name);
            model.Participants = new List<Author>();
            model.Participants.Add(userAsAuthor);
            model.Date = DateTime.Now;
            _serv.AddGrant(model);

            return RedirectToAction("Create");
        }

        public IActionResult PublicationForm()
        {
            return View();
        }

        public IActionResult DepartmentWorkIntroForm()
        {
	        return View();
        }

		[HttpPost]
        public async Task<IActionResult> SavePublication([FromForm]CreatePublicationModel model)
        {
            var currentUser = await _userServ.GetUserAsync(User);
            if (model.Authors.IndexOf(currentUser.Name) == -1)
            {
                model.Authors += ", " + currentUser.Name;
            }
            model.Date = DateTime.Now;
            _serv.AddPublication(model);

            return RedirectToAction("Create");
        }

        [HttpPost]
        public IActionResult SearchPubilcation([FromForm] SearchPublicationModel searchParam)
        {
            var searchRes = _serv.SearchPublications(searchParam.Name, searchParam.Author);
            if (searchRes.Publications == null)
            {
                return View("SearchPublication", new SearchPublicationModel
                {
                    Error = "Пошук не дав результатів"
                });
            }
            return View("PublicationTable", searchRes);
        }

        [HttpPost]
        public IActionResult SearchDepWork([FromForm] SearchDepWorkModel searchParam)
        {
            var searchRes = _serv.SearchPublications(searchParam.Name, searchParam.Author);
            if (searchRes.Publications == null)
            {
                return View("SearchPublication", new SearchPublicationModel
                {
                    Error = "Пошук не дав результатів"
                });
            }
            return View("PublicationTable", searchRes);
        }

        public IActionResult SearchPubilcationForm()
        {
            return View("SearchPublication");
        }

        public IActionResult SearchDepWorkForm()
        {
            return View("SearchDepWork");
        }

        [HttpGet]
        public IActionResult AddAuthor([FromQuery]int pubId, [FromQuery]string author)
        {
            author = System.Net.WebUtility.UrlDecode(author);
            _serv.AddAuthor(pubId, author);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SaveReportItem([FromForm]ReportItem model)
        {
            var currentUser = await _userServ.GetUserAsync(User);
            model.User = currentUser.Name;
            model.Date = DateTime.Now;
            _serv.AddReportItem(model);

            return RedirectToAction("Create");
        }

        [HttpPost]
        public async Task<IActionResult> SaveDepartmentWorkIntro([FromForm]DepartmentWorkIntro model) {
	        var currentUser = await _userServ.GetUserAsync(User);
	        model.Faculty = currentUser.Faculty;
            _serv.AddDepartmentWorkIntro(model);
	        return RedirectToAction("Create");
        }

	}
}
