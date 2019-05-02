using System.Collections.Generic;
using ScientificReportData.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScientificReportData.Models
{
	public class Grant : IEntity<int> 
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Name { get; set; }

		public ICollection<Author> Participants { get; set; }
	}
}