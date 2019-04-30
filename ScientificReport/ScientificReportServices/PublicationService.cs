using ScientificReportData;
using ScientificReportData.Enums;
using ScientificReportData.Models;
using ScientificReportServices.Interfaces;
using System;
using System.Collections.Generic;
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

        public Publication AddPublication(CreatePublicationModel model)
        {
            var authordNames = model.Authors.Split(" ");
            List<Author> authors = new List<Author>();
            foreach (var name in authordNames)
            {
                var author = _unitOfWork.GetAuthorByName(name);
                if (author == null)
                {
                    author = new Author { Name = name };
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

            var res = _unitOfWork.PublicationRepository.Create(publ);
            return res;
        }
    }
}
