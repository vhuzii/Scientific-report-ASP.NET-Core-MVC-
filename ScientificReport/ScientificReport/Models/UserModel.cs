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
        public string Faculty { get; set; }
        public string Department { get; set; }
        public bool Status { get; set; }
    }
}
