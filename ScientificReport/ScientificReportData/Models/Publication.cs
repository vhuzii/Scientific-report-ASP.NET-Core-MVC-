using ScientificReportData.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ScientificReportData.Models
{
    public class Publication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        
        public DateTime Date { get; set; }
        
        public string Time { get; set; }

        public string Topic { get; set; }

        public PublicationStatus Status { get; set; }

        public ICollection<Author> Authors { get; set; }
    }
}
