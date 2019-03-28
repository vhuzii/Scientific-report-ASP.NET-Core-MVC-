using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScientificReport.Data.Models;

namespace ScientificReport.Services
{
    public class UserService : IUserService
    {
        public User CurrentUser { get; set; }
    }
}
