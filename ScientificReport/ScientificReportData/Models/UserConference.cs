using ScientificReportData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificReportData.Models
{
    public class UserConference : IEntity<int>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ConferenceId { get; set; }
    }
}
