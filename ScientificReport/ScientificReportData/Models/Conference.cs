using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificReportData.Models
{
    public class Conference
    {
        public int Id {get;set;}
        public int Likes { get; set; }
        public int Watches { get; set; }
        public string ImgPath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
