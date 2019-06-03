using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificReportData.Models.Responses
{
    public class DepWorkViewModel
    {
        public List<DepartmentWork> DepWorks { get; set; }
        public List<string> Authors { get; set; }
    }
}
