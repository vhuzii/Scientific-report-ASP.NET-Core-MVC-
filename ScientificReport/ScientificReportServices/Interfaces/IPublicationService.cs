using ScientificReportData.Models;
using ScientificReportData.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ScientificReportData;

namespace ScientificReportServices.Interfaces
{
    public interface IPublicationService
    {
        UnitOfWork UOF { get; }
        Publication AddPublication(CreatePublicationModel model);
        PubliEditViewModel SearchPublications(string searchParam, string author);
        void AddAuthor(int pubId, string author);
    }
}
