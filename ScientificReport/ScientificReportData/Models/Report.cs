using ScientificReportData.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ScientificReportData.Models
{
    public class Report : IEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

        public DateTime Date { get; set; }

        public string DepartmentWork { get; set; }

        public string Conferences { get; set; }

        public string Intro { get; set; }

        public string Contetnt { get; set; }
    }
}
