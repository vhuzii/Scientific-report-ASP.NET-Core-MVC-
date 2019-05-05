using ScientificReportData;
using ScientificReportData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScientificReportServices
{
    public class ReportItemsService : IReportItemsService
    {
        private readonly UnitOfWork _unitOfWork;

        public ReportItemsService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DepartmentWork AddDepartmentWork(DepartmentWork dw)
        {
            var res = _unitOfWork.DepartmentWorkRepository.Create(dw);
            return res;
        }

        public Grant AddGrant(Grant gr)
        {
            var res = _unitOfWork.GrantRepository.Create(gr);
            return res;
        }

        public Author GetUserAsAuthor(User user)
        {
            var userAturhor = _unitOfWork.AuthorRepository.GetAll().FirstOrDefault(u => u.Name == user.Name);
            if( userAturhor == null )
            {
                userAturhor = _unitOfWork.AuthorRepository.Create(new Author { Name = user.Name });
            }
            return userAturhor;
        }

        public Publication AddPublication(Publication pb)
        {
            var res = _unitOfWork.PublicationRepository.Create(pb);
            return res;
        }
    }
}
