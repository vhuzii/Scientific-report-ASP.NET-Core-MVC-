using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificReportData.Models
{
    public class CreatePublicationModel
    {
        public DateTime Date { get; set; }

        public string Topic { get; set; }

        public string Status { get; set; }

        public string Authors { get; set; }
    }
}
