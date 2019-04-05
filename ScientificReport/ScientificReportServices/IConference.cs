using ScientificReportData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificReportServices
{
    public interface IConference
    {
        IEnumerable<Conference> getAll();
        void Add(Conference newElem);
        Conference getById(int Id);
        int getLikesById(int Id);
        int getWatchesById(int Id);
        string getImgPathById(int Id);
        string getTitleById(int Id);
        string getDescriptionById(int Id);
        DateTime getDateById(int Id);
    }
}
