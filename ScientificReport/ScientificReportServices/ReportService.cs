using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScientificReportData.Models;

namespace ScientificReportServices
{
    public class ReportService : IReportService

    {
        public Report CreateReport(CreateReportModel createModel, User currentUser)
        {
            var report = new Report();
			// TODO Заповнити фейковідані юзера
            var fakeUser = new User() {

            };
            report.Intro = GenerateIntro(fakeUser); // TODO замінити фейк бзера на currentUser
            //todo the rest
            return report;
        }

        private string GenerateIntro(User user)
        {
            var intro = new StringBuilder();
            intro.Append(
              $"Рік народження: {user.Birthdate.Year}")
                .Append(Environment.NewLine
             )
                .Append($"Рік закінчення ВНЗ {user.GraduationDate}").Append(Environment.NewLine
             )
                .Append($"Науковий ступінь: {user.DegreeLevel} рік захисту {user.DegreeDate.Year}")
                .Append(
             Environment.NewLine
             )
                .Append($"Вчене звання: {user.Title} рік присвоєння {user.TitleDate.Year}"
            );

            return intro.ToString();
        }
    }
}
