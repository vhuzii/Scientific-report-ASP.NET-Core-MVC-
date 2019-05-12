using Microsoft.EntityFrameworkCore;
using ScientificReportData;
using ScientificReportData.Enums;
using ScientificReportData.Models;
using ScientificReportData.Models.Responses;
using ScientificReportServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientificReportServices
{
    public class PublicationService : IPublicationService
    {
        private readonly UnitOfWork _unitOfWork;

        public PublicationService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PubliEditViewModel SearchPublications(string searchParam = "", string author = "")
        {
            searchParam = searchParam ?? "";
            author = author ?? "";
            var args = searchParam.Split(" ");
            var publs = CreatePublViewModel();
            var resPubls = publs.Publications.Where(p => (args.Any(a => p.Topic.IndexOf(a) != -1)));
            var resAuthors = resPubls.Where(p => p.Authors.Any(a => a.Name.Contains(author)));
            var res = new PubliEditViewModel
            {
                Publications = resAuthors?.ToList(),
                Authors = publs.Authors
            };
            return res;
        }

        public void AddAuthor(int pubId, string author)
        {
            var pub = _unitOfWork.PublicationRepository.Set.Include(p => p.Authors).FirstOrDefault(p => p.Id == pubId);
            var aut = _unitOfWork.AuthorRepository.Create(new Author { Name = author });
            pub.Authors.Add(aut);
            _unitOfWork.PublicationRepository.Update(pub);
        }

        public Publication AddPublication(CreatePublicationModel model)
        {
            var authordNames = model.Authors.Split(", ");
            List<Author> authors = new List<Author>();
            foreach (var name in authordNames)
            {
                var author = new Author { Name = name };
                _unitOfWork.AuthorRepository.Create(author);
                authors.Add(author);
            }
            var publ = new Publication
            {
                Date = model.Date,
                Authors = authors.ToList(),
                Status = model.Status,
                Topic = model.Topic,
                Type = model.Type
            };

            var res = _unitOfWork.PublicationRepository.Create(publ);
            return res;
        }

        public PubliEditViewModel CreatePublViewModel()
        {
            var publs = _unitOfWork.PublicationRepository.Set.Include(c => c.Authors)?.ToList();
            var authors = _unitOfWork.AuthorRepository.GetAll().Select(a => a.Name)?.ToList();
            return new PubliEditViewModel
            {
                Publications = publs,
                Authors = authors
            };
        }
    }
}
