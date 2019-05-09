using ScientificReportData.Models;
using ScientificReportData.Repositories;
using ScientificReportServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificReportServices
{
    class UserConferenceService : IUserConferenceService
    {
        private Repository<UserConference, int> repository;

        public UserConferenceService(Repository<UserConference,int> repository)
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
    }
}
