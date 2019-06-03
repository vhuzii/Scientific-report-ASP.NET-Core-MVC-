using ScientificReportData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificReportServices.Interfaces
{
    public interface IConferenceCommentsService
    {
        IEnumerable<ConferenceComments> getAll();
        void Add(ConferenceComments newElem);
        void Update(ConferenceComments newElem);
        ConferenceComments getById(int Id);

    }
}
