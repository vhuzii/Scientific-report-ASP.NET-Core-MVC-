﻿using ScientificReportData.Models;

namespace ScientificReportServices
{
    public interface IReportItemsService
    {
        DepartmentWork AddDepartmentWork(DepartmentWork dw);
        Grant AddGrant(Grant gr);
        Publication AddPublication(Publication pb);
    }
}