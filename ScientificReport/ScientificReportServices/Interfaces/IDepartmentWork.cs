using ScientificReportData.Models;
using ScientificReportData.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificReportServices.Interfaces
{
    public interface IDepWorkService
    {
        DepWorkViewModel SearchDepartmentWork(string searchParam, string author, string depName);
        void AddAuthor(int depWorkId, string author);
    }
}
