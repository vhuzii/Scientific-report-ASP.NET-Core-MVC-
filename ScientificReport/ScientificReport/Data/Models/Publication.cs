using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ScientificReport.Data.Enums;

namespace ScientificReport.Data.Models
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

        public IEnumerable<string> Authors { get; set; }
    }
}
