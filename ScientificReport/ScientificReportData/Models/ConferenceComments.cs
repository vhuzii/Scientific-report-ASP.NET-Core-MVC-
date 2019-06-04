using System;
using System.Collections.Generic;
using System.Text;
using ScientificReportData.Interfaces;
namespace ScientificReportData.Models
{
    public class ConferenceComments : IEntity<int>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ConferenceId { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
    }
}
