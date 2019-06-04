using ScientificReportData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientificReport.Models
{
    public class ConferenceDetailsModel
    {
        public Conference ConferenceInfo { get; set; }
        public bool TakePart { get; set; }
        public IEnumerable<string> UserNames { get; set; }
        public IEnumerable<ConferenceComments> Comments { get; set; }
    }
}
