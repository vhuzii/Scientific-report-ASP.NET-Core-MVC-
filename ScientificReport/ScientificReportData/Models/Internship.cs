using ScientificReportData.Interfaces;

namespace ScientificReportData.Models {
	public class Internship : IEntity<int>
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}