using System;
using System.Collections.Generic;
using ScientificReportData.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ScientificReportData.Models
{
	public class Grant : IEntity<int> 
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Name { get; set; }

        public string Description { get; set; }

		public ICollection<Author> Participants { get; set; }

        public DateTime Date { get; set; }
    }
}