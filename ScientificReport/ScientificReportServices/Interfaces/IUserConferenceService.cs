using System;
using System.Collections.Generic;
using System.Text;
using ScientificReportData.Models;
namespace ScientificReportServices.Interfaces
{
    public interface IUserConferenceService
    {
        void Add(UserConference newElem);
        UserConference getById(int Id);
    }
}
