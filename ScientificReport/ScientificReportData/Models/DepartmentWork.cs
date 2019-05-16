using ScientificReportData.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ScientificReportData.Models
{
    public class DepartmentWork : IEntity<int>
    {
	    [Key]
	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
	    public string Topic { get; set; }
        public ICollection<Author> Authors { get; set; }
		public string Category { get; set; }
        public string Intro { get; set; }
        public string Content { get; set; }
    }

}
