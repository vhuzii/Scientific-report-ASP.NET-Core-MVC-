using Microsoft.EntityFrameworkCore;
using ScientificReportData;
using ScientificReportData.Models;
using ScientificReportData.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScientificReportServices
{
    public class ReportService : IReportService
    {
        private readonly UnitOfWork unitOfWork;
        private User user;

        public ReportService(UnitOfWork uow)
        {
            this.unitOfWork = uow;
        }

        public Report CreateReport(User currentUser)
        {
            user = new User()
            {
                Birthdate = DateTime.Now,
            };
            var report = new Report();

            report.Date = DateTime.Today.Date;
            report.Intro = GenerateIntro();
            report.DepartmentWork = GenerateDepartmentWorks();
            unitOfWork.ReportRepository.Create(report);
            return report;
        }

        public ReportViewModel CreateViewModel(User currentUser,DateTime start, DateTime end)
        {
            var publications = unitOfWork.PublicationRepository.Set.Include(p => p.Authors).Where(p => p.Authors != null && p.Authors.Any(a => a.Name == currentUser.Name)).Where(d =>d.Date > start && d.Date < end)?.ToList();
            var grants = unitOfWork.GrantRepository.Set.Include(p => p.Participants).Where(p => p.Participants.Any(a => p.Participants != null && a.Name == currentUser.Name)).Where(d => d.Date > start && d.Date < end)?.ToList();
            var depWorks = unitOfWork.DepartmentWorkRepository.Set.Include(p => p.Authors).Where(p => p.Authors != null && p.Authors.Any(a => a.Name == currentUser.Name)).Where(d => d.Date > start && d.Date < end)?.ToList();
            var conferences = unitOfWork.ConferenceRepository.Set.Include(p => p.Participants).Where(p => p.Participants != null && p.Participants.Any(a => a.Name == currentUser.Name)).Where(d => d.Date > start && d.Date < end)?.ToList();
            var repItems = unitOfWork.ReportItemRepository.GetAll().Where(p => p.User == currentUser.Name).Where(d => d.Date > start && d.Date < end)?.ToList();
            var publTypesGroup = publications.Where(d => d.Date > start && d.Date < end).GroupBy(p => p.Type)?.ToList();
            var recentPubls = publications.Where(d => d.Date > start && d.Date < end).GroupBy(p => p.Type)?.ToList();
            var publTypes = publTypesGroup?.Select(g => g.Key).ToList();
            var summary = new List<PublSummary>();
            if (publTypes != null)
            {
                foreach (var t in publTypes)
                {
                    summary.Add(new PublSummary
                    {
                        PubName = t,
                        Year = recentPubls?.FirstOrDefault(p => p.Key == t)?.Count() ?? 0,
                        Total = publTypesGroup?.FirstOrDefault(p => p.Key == t)?.Count() ?? 0
                    });
                }
            }
            var result = new ReportViewModel
            {
                User = currentUser,
                Publications = publications ?? new List<Publication>(),
                DepartmentWorks = depWorks ?? new List<DepartmentWork>(),
                Conferences = conferences ?? new List<Conference>(),
                Grants = grants ?? new List<Grant>(),
                RepItems = repItems ?? new List<ReportItem>(),
                PubSummary = summary
            };
            return result;
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
            var works = unitOfWork.DepartmentWorkRepository.GetAll().Where(w => w.Authors != null && w.Authors.Any( p => p.Name == user.UserName));
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
            var confs = unitOfWork.ConferenceRepository.GetAll().Where(c => c.Participants != null && c.Participants.Any(p => p.Name == user.Name));
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

        private string GenerateGrants()
        {
            var userGrants = unitOfWork.GrantRepository.GetAll().Where(c => c.Participants != null && c.Participants.Any(p => p.Name == user.Name));
            var grants = new StringBuilder();
            grants
               .Append("Приймав участь в таких грантах: ")
               .Append(Environment.NewLine);
            foreach (var grant in userGrants)
            {
                grants.Append($"{grant.Name};")
               .Append(Environment.NewLine);
            }

            return grants.ToString();
        }

        private string GenerateInternships()
        {
            var internships = new StringBuilder();
            internships
               .Append("Наукові стажування: ")
               .Append(Environment.NewLine);
            foreach (var internship in user.Internships)
            {
                internships.Append($"{internship.Name};")
                   .Append(Environment.NewLine);
            }

            return internships.ToString();
        }

        private string GeneratePublications()
        {
            var publications = new StringBuilder();
            publications
               .Append("Публікації: ")
               .Append(Environment.NewLine);
            foreach (var userPublication in user.Publications)
            {
                publications.Append(userPublication.Topic)
                   .Append($", Дата: {userPublication.Date}")
                   .Append(Environment.NewLine);
                publications
                   .Append($"Автори: ");
                foreach (var userPublicationAuthor in userPublication.Authors)
                {
                    publications.Append($"{userPublicationAuthor} ");
                }
            }

            return publications.ToString();
        }

        private string GenerateArticles()
        {
            var publications = new StringBuilder();
            publications
               .Append("Публікації: ")
               .Append(Environment.NewLine);
            foreach (var userPublication in user.Publications)
            {
                publications.Append(userPublication.Topic)
                   .Append($", Дата: {userPublication.Date}")
                   .Append(Environment.NewLine);
                if (userPublication.Authors.Any())
                {
                    publications
                       .Append($"Автори: ");
                    foreach (var userPublicationAuthor in userPublication.Authors)
                    {
                        publications.Append($"{userPublicationAuthor} ");
                    }
                }
            }

            return publications.ToString();
        }
    }
}
