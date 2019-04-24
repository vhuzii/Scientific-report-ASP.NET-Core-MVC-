using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScientificReport.Data.DataAccess;
using ScientificReportData.Interfaces;
using ScientificReportData.Models;

namespace ScientificReportServices
{
    public class ReportService : IReportService
    {
        private readonly IRepository<Report, int> reportRepository;
        private readonly IRepository<Author, int> authorRepository;
        private readonly IRepository<DepartmentWork, int> departmentWorkRepository;
        private readonly IRepository<Conference, int> conferenceRepository;
		private User user;

        public ReportService(IRepository<Report, int> reportRepository, 
	        IRepository<Author, int> authorRepository,
	        IRepository<DepartmentWork, int> departmentWorkRepository,
	        IRepository<Conference, int> conferenceRepository)
        {
            this.reportRepository = reportRepository;
            this.authorRepository = authorRepository;
            this.departmentWorkRepository = departmentWorkRepository;
            this.conferenceRepository = conferenceRepository;
        }

        public Report CreateReport(User currentUser) {
	        user = new User() {
				Birthdate = DateTime.Now,
			}; 
			var report = new Report();

			// Воно кидає ексепшн поки тому я закоментив
            //report.Date = DateTime.Today.Date;
            //report.Intro = GenerateIntro();
            //report.DepartmentWork = GenerateDepartmentWorks();
            //report.Conferences = GenerateConferences();
            //todo the rest
            return report;
        }

        private string GenerateIntro()
        {
            var intro = new StringBuilder();
            intro.Append(
              $"Рік народження: {user.Birthdate.Year}")
                .Append(Environment.NewLine)
                .Append($"Рік закінчення ВНЗ {user.GraduationDate}").Append(Environment.NewLine)
                .Append($"Науковий ступінь: {user.DegreeLevel} рік захисту {user.DegreeDate.Year}")
                .Append(Environment.NewLine)
                .Append($"Вчене звання: {user.Title} рік присвоєння {user.TitleDate.Year}"
            );

            return intro.ToString();
        }

        private string GenerateDepartmentWorks()
        {
            var userAsAuthor = authorRepository.GetAll().FirstOrDefault(a => a.Name == user.Name);
            if (userAsAuthor == null) return "";
            var works = departmentWorkRepository.GetAll().Where(w => w.Authors.Contains(userAsAuthor));
			var section = new StringBuilder();

            foreach (var work in works)
            {                
                section.Append($"Teмa: {work.Topic}, {work.Category}, {work.Intro}")
                    .Append(Environment.NewLine)
                    .Append(Environment.NewLine)
                    .Append(work.Content)
                    .Append(Environment.NewLine)
                    .Append(Environment.NewLine);
            }

            return section.ToString();
        }

        private string GenerateConferences()
        {
            var confs = conferenceRepository.GetAll().Where(c => c.Participants.Any(p => p.Name == user.Name));
            var section = new StringBuilder();

            foreach (var conf in confs)
            {
                section.Append($"{conf.Title}")
                    .Append(Environment.NewLine)
                    .Append(conf.Date)
                    .Append(Environment.NewLine)
                    .Append(Environment.NewLine);
            }

            return section.ToString();
        }
    }
}
