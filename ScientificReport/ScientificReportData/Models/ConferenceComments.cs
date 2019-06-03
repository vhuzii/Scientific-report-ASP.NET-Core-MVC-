using ScientificReportData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificReportData.Models
{
    public class ConferenceComments:IEntity<int>
    {
        public int Id { get; set; }
        public int ConferenceId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string text { get; set; }
        public DateTime date { get; set; }
    }
}
