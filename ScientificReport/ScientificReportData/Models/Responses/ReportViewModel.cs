using System.Collections.Generic;

namespace ScientificReportData.Models
{
   public class ReportViewModel
   {
      public User User { get; set; }
      public List<Publication> Publications { get; set; }
      public List<DepartmentWork> DepartmentWorks { get; set; }
      public List<Conference> Conferences { get; set; }
      public List<Grant> Grants { get; set; }
      public List<ReportItem> RepItems { get; set; }
      public List<PublSummary> PubSummary { get; set; }
   }
}
