using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScientificReportData.Models;

namespace ScientificReportServices
{
    public interface IReportService
    {
        Report CreateReport(User currentUser);
        ReportViewModel CreateViewModel(User curUser, DateTime start, DateTime End);
    }
}
