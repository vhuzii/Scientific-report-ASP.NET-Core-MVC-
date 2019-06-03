using ScientificReportData;
using ScientificReportData.Models;
using ScientificReportData.Models.Responses;
using ScientificReportServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScientificReportServices
{
    public class ReportItemsService : IReportItemsService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IPublicationService _publServ;
        private readonly IDepWorkService _depWorkServ;

        public ReportItemsService(UnitOfWork unitOfWork, IPublicationService publServ, IDepWorkService depWorkServ )
        {
            _unitOfWork = unitOfWork;
            _publServ = publServ;
            _depWorkServ = depWorkServ;
        }

        public DepartmentWork AddDepartmentWork(DepartmentWork dw)
        {
            AddAuthors(dw.Authors.Select(a => a.Name).ToList());
            var res = _unitOfWork.DepartmentWorkRepository.Create(dw);
            return res;
        }

        public Grant AddGrant(Grant gr)
        {
            AddAuthors(gr.Participants.Select(a => a.Name).ToList());
            var res = _unitOfWork.GrantRepository.Create(gr);
            return res;
        }

        public Author GetUserAsAuthor(string usename)
        {
            var aut = _unitOfWork.AuthorRepository.Create(new Author
            {
                Name = usename
            });

            return aut;
        }
        public Publication AddPublication(CreatePublicationModel pb)
        {
            var res = _publServ.AddPublication(pb);
            return res;
        }

        public ReportItem AddReportItem(ReportItem ri)
        {
            var res = _unitOfWork.ReportItemRepository.Create(ri);
            return res;
        }

        public void AddAuthors(List<string> authors)
        {
            foreach (var name in authors)
            {
                var author = _unitOfWork.GetAuthorByName(name);
                if (author == null)
                {
                    author = new Author { Name = name };
                    _unitOfWork.AuthorRepository.Create(author);
                }
            }
        }

        public void AddAuthor(int pubId, string author)
        {
            _publServ.AddAuthor(pubId, author);
        }

        public PubliEditViewModel SearchPublications(string searchParam, string author)
        {
            return _publServ.SearchPublications(searchParam, author);
        }

        public void AddAuthorDepWork(int depId, string author)
        {
            _publServ.AddAuthor(depId, author);
        }

        public DepWorkViewModel SearchDepWork(string searchParam, string author, string department)
        {
            return _depWorkServ.SearchDepartmentWork(searchParam, author, department);
        }

        public IEnumerable<string> GetPublicationIntrosByUser(User user) 
		{
			return this._unitOfWork.DepartmentWorkTopicRepository.GetAll().Where(intro => intro.Faculty == user.Faculty).Select(s => s.Intro);
		}

		public void AddDepartmentWorkIntro(DepartmentWorkIntro model) 
		{
			_unitOfWork.DepartmentWorkTopicRepository.Create(model);
		}
	}
}
