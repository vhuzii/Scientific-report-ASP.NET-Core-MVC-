using ScientificReportData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScientificReportServices.Interfaces
{
    public interface IPublicationService
    {
        Publication AddPublication(CreatePublicationModel model);
    }
}
