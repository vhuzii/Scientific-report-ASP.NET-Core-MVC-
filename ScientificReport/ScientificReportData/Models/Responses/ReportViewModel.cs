using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientificReportData.Models
{
    public class ReportViewModel
    {
        public User User { get; set; }
        public List<Publication> Publications { get; set; }
        public List<DepartmentWork> DepartmentWorks { get; set; }
        public List<Conference> Conferences { get; set; }
        public List<Grant> Grants { get; set; }
    }
}
