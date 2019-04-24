using ScientificReport.Data.DataAccess;
using ScientificReportData;
using ScientificReportData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ScientificReportData.Interfaces;

namespace ScientificReportServices
{
    public class ConferenceService : IConferenceService
    {
        private IRepository<Conference, int> repository;

        public ConferenceService(IRepository<Conference, int> repository)
        {
            this.repository = repository;
        }

        public void Add(Conference newElem)
        {
            repository.Create(newElem);
        }

        public IEnumerable<Conference> getAll()
        {
            return repository.GetAll();
        }

        public Conference getById(int id) 
        {
	        return repository.Get(id);
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

        public void Update(Conference newElem)
        {
            repository.Update(newElem);
        }
    }
}
