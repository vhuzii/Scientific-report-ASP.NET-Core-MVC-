using ScientificReportData.Interfaces;
using ScientificReportData.Models;
using ScientificReportData.Repositories;
using ScientificReportServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificReportServices
{
    public class UserConferenceService : IUserConferenceService
    {
        private IRepository<UserConference, int> repository;

        public UserConferenceService(IRepository<UserConference, int> repository)
        {
            this.repository = repository;
        }

        public void Add(UserConference newElem)
        {
            repository.Create(newElem);
        }

        public UserConference getById(int id)
        {
            return repository.Get(id);
        }

        public IEnumerable<UserConference> getAll()
        {
            return repository.GetAll();
        }
        public void Delete(UserConference userToDelete)
        {
            repository.Delete(userToDelete.Id);
        }
    }
}
