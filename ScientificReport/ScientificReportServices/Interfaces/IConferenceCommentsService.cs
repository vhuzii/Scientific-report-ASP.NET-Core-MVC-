using ScientificReport.Data.DataAccess;
using ScientificReportData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ScientificReportData.Interfaces;


namespace ScientificReportServices.Interfaces
{
    public interface IConferenceCommentsService
    {
        void Add(ConferenceComments newElem);
        ConferenceComments getById(int Id);
        IEnumerable<ConferenceComments> getAll();
        void Update(ConferenceComments comToEdit);
        void Delete(ConferenceComments comToDel);
    }
}
