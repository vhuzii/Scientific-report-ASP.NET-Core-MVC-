using ScientificReportData;
using ScientificReportData.Models;
using System;
using System.Collections.Generic;
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

        public Publication AddPublication(Publication pb)
        {
            var res = _unitOfWork.PublicationRepository.Create(pb);
            return res;
        }
    }
}
