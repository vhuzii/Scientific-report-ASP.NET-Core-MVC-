using ScientificReport.Data.DataAccess;
using ScientificReportData;
using ScientificReportData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScientificReportServices
{
    public class ConferenceService : IConference
    {
        private ReportContext _context;

        public ConferenceService(ReportContext context)
        {
            _context = context;
        }

        public void Add(Conference newElem)
        {
            _context.Add(newElem);
            _context.SaveChanges();
        }

        public IEnumerable<Conference> getAll()
        {
            return _context.Conferences;
        }

        public Conference getById(int Id)
        {
            return _context.Conferences.FirstOrDefault(asset => asset.Id == Id);
        }

        public DateTime getDateById(int Id)
        {
            return getById(Id).Date;
        }

        public string getDescriptionById(int Id)
        {
            return getById(Id).Description;
        }

        public string getImgPathById(int Id)
        {
            return getById(Id).ImgPath;
        }

        public int getLikesById(int Id)
        {
            return getById(Id).Likes;
        }

        public string getTitleById(int Id)
        {
            return getById(Id).Title;
        }

        public int getWatchesById(int Id)
        {
            return getById(Id).Watches;
        }
    }
}
