using ScientificReportData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificReportData.Models
{
    public class Conference : IEntity<int>
    {
        public int Id {get;set;}
        public int Likes { get; set; }
        public int Watches { get; set; }
        public string ImgPath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Author> Participants {get; set; }
        public string Comments { get; set; }
    }
}
