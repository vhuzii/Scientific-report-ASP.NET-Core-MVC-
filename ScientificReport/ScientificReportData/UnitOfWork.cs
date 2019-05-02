using ScientificReportData.Interfaces;
using ScientificReportData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificReportData 
{
	public class UnitOfWork 
	{
		public readonly IRepository<Report, int> ReportRepository;
		public readonly IRepository<Author, int> AuthorRepository;
		public readonly IRepository<DepartmentWork, int> DepartmentWorkRepository;
		public readonly IRepository<Conference, int> ConferenceRepository;
		public readonly IRepository<Grant, int> GrantRepository;

		public UnitOfWork(IRepository<Report, int> reportRepository,
			IRepository<Author, int> authorRepository,
			IRepository<DepartmentWork, int> departmentWorkRepository,
			IRepository<Conference, int> conferenceRepository,
			IRepository<Grant, int> grantRepository) 
		{
			this.ReportRepository = reportRepository;
			this.AuthorRepository = authorRepository;
			this.DepartmentWorkRepository = departmentWorkRepository;
			this.ConferenceRepository = conferenceRepository;
			this.GrantRepository = grantRepository;
		}
	}
}
