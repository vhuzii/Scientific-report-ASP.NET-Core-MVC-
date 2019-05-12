using ScientificReportData.Models;
using ScientificReportData.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScientificReportServices.Interfaces
{
    public interface IPublicationService
    {
        Publication AddPublication(CreatePublicationModel model);
        PubliEditViewModel SearchPublications(string searchParam, string author);
        void AddAuthor(int pubId, string author);
    }
}
