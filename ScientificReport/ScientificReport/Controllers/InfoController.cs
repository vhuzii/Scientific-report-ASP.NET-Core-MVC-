using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

      public InfoController( IReportItemsService serv, UserManager<User> userService )
      {
         _serv = serv;
         _userServ = userService;
      }

      public IActionResult Create()
      {
         return View();
      }

      public IActionResult DepartmentWorkForm()
      {
         return View();
      }

      public IActionResult ReportItemFrom( string itemType )
      {
         ViewData["itemType"] = itemType;
         ViewData["shortType"] = itemType.Split(" ").Take(2).Aggregate( (a,b) => a + b);
         return View();
      }

      [HttpPost( "SaveDepartmentWork" )]
      public async Task<IActionResult> SaveDepartmentWork( [FromForm]DepartmentWork model )
      {
         var currentUser = await _userServ.GetUserAsync( User );
         var userAuthor = _serv.GetUserAsAuthor( currentUser );
         model.Authors = new List<Author>();
         model.Authors.Add( userAuthor );

         _serv.AddDepartmentWork( model );

         return RedirectToAction( "Create" );
      }

      public IActionResult GrantsForm()
      {
         return View();
      }

      [HttpPost]
      public async Task<IActionResult> SaveGrant( [FromForm]Grant model )
      {
         var currentUser = await _userServ.GetUserAsync( User );
         var userAuthor = _serv.GetUserAsAuthor( currentUser );
         model.Participants = new List<Author>();
         model.Participants.Add( userAuthor );

         _serv.AddGrant( model );

         return RedirectToAction( "Create" );
      }

      public IActionResult PublicationForm()
      {
         return View();
      }

      [HttpPost]
      public async Task<IActionResult> SavePublication( [FromForm]Publication model )
      {
         var currentUser = await _userServ.GetUserAsync( User );
         var userAuthor = _serv.GetUserAsAuthor( currentUser );
         model.Authors = new List<Author>();
         model.Authors.Add( userAuthor );

         _serv.AddPublication( model );

         return RedirectToAction( "Create" );
      }

      [HttpPost]
      public async Task<IActionResult> SaveReportItem( [FromForm]ReportItem model )
      {
         var currentUser = await _userServ.GetUserAsync( User );
         model.User = currentUser.Name;

         _serv.AddReportItem( model );

         return RedirectToAction( "Create" );
      }

   }  
}
