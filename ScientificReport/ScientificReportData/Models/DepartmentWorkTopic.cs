using ScientificReportData.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificReportData.Models 
{
	public class DepartmentWorkIntro : IEntity<int> 
	{
		public int Id { get; set; }
		public string Intro { get; set; }
		public string Faculty { get; set; }
	}
}
