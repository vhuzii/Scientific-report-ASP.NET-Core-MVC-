using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ScientificReport.Data.Models
{
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

        public DateTime Date { get; set; }

        public DepartmentWork DepartmentWork { get; set; }

        public string Intro { get; set; }

        public string Contetnt { get; set; }
    }
}
