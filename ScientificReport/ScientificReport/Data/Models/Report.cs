using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScientificReport.Data.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Contetnt { get; set; }
    }
}
