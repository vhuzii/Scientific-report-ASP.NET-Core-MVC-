using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScientificReportData.Models;

namespace ScientificReportServices
{
    public class UserService : IUserService
    {
        public User CurrentUser { get; set; }
    }
}
