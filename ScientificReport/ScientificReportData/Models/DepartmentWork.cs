using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScientificReportData.Models
{
    public class DepartmentWork
    {
        [Key]
        public string Topic { get; set; }
        public ICollection<Author> Authors { get; set; }
        public string Intro { get; set; }
        public string Content { get; set; }
    }
}
