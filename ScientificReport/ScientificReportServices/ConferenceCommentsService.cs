using System;
using System.Collections.Generic;
using System.Text;
using ScientificReportData.Interfaces;
using ScientificReportData.Models;
using ScientificReportServices.Interfaces;

namespace ScientificReportServices
{
    public class ConferenceCommentsService : IConferenceCommentsService
    {
        private IRepository<ConferenceComments, int> repository;

        public ConferenceCommentsService(IRepository<ConferenceComments, int> repository)
        {
            this.repository = repository;
        }
        public void Add(ConferenceComments newElem)
        {
            repository.Create(newElem);
        }

        public IEnumerable<ConferenceComments> getAll()
        {
            return repository.GetAll();
        }

        public ConferenceComments getById(int Id)
        {
            return repository.Get(Id);
        }

        public void Update(ConferenceComments newElem)
        {
            repository.Update(newElem);
        }

        public void Delete(ConferenceComments userToDelete)
        {
            repository.Delete(userToDelete.Id);
        }
    }
}
