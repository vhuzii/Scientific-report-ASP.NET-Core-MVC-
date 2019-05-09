using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientificReport.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public bool Status { get; set; }
    }
}
