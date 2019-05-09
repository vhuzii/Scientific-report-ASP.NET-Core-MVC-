using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScientificReportData;
using ScientificReportData.Interfaces;
using ScientificReportData.Models;

namespace ScientificReportServices
{
    public class UserService : IUserService
    {
        public User CurrentUser { get; set; }

        private UnitOfWork unitOfWork;

        public UserService(UnitOfWork uow)
        {
            this.unitOfWork = uow;
        }        

        public IEnumerable<User> getAll()
        {
            return unitOfWork.UserRepository.GetAll();
        }
    }
}
