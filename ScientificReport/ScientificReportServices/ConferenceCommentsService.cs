using ScientificReportData.Interfaces;
using ScientificReportData.Models;
using ScientificReportData.Repositories;
using ScientificReportServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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

        public void Delete(ConferenceComments comToDel)
        {
            repository.Delete(comToDel.Id);
        }

        public IEnumerable<ConferenceComments> getAll()
        {
            return repository.GetAll();
        }

        public ConferenceComments getById(int Id)
        {
            return repository.Get(Id);
        }

        public void Update(ConferenceComments comToEdit)
        {
            repository.Update(comToEdit);
        }
    }
}
