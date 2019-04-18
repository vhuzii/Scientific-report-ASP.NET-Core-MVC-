﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScientificReportData.Models;

namespace ScientificReportServices
{
    public interface IReportService
    {
        Report CreateReport(CreateReportModel createModel, User currentUser);
    }
}