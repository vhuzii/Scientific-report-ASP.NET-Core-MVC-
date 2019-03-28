using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScientificReport.Data.Models;

namespace ScientificReport.Services
{
    public interface IReportService
    {
        Report CreateReport(CreateReportModel createModel, User currentUser);
    }
}
