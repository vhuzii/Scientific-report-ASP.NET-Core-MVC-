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

namespace ScientificReport.Controllers
{
    public class PublicationController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public PublicationController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SavePublication([FromForm]CreatePublicationModel model)
        {
            var authordNames = model.Authors.Split(" ");
            List<Author> authors = new List<Author>();
            foreach (var name in authordNames)
            {
                var author = _unitOfWork.GetAuthorByName(name);
                if (author == null)
                {
                    new Author { Name = name };
                    _unitOfWork.AuthorRepository.Create(author);
                }
                authors.Add(author);
            }
            var publ = new Publication
            {
                Date = model.Date,
                Authors = authors.ToArray(),
                Status = EnumMappers.GetPublicationStatus(model.Status),
                Topic = model.Topic,
            };

            _unitOfWork.PublicationRepository.Create(publ);

            return RedirectToAction("Create");
        }
    }
}
