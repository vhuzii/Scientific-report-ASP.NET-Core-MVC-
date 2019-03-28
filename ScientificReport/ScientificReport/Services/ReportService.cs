using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScientificReport.Data.Models;

namespace ScientificReport.Services
{
    public class ReportService : IReportService

    {
        public Report CreateReport(CreateReportModel createModel, User currentUser)
        {           
            var report = new Report();

            report.Intro = GenerateIntro(currentUser);
            //todo the rest
            return report;        
        }

        private string GenerateIntro(User user)
        {
            var intro = new StringBuilder();
            intro.Append(
              $"Рік народження: {user.Birthdate.Year}" + Environment.NewLine
             + $"Рік закінчення ВНЗ {user.GraduationDate}" + Environment.NewLine
             + $"Науковий ступінь: {user.DegreeLevel} рік захисту {user.DegreeDate.Year}" +
             Environment.NewLine
             + $"Вчене звання: {user.Title} рік присвоєння {user.TitleDate.Year}"
            );

            return intro.ToString();
        }
    }
}
