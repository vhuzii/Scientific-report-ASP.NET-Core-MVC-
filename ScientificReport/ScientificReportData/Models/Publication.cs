﻿using ScientificReportData.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ScientificReportData.Interfaces;


namespace ScientificReportData.Models
{
    public class Publication : IEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        
        public DateTime Date { get; set; }
        
        public string Type { get; set; }

        public string Topic { get; set; }

        public string Status { get; set; }

        public ICollection<Author> Authors { get; set; }
    }
}
