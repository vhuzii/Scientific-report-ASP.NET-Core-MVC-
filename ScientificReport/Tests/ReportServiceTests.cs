using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac.Extras.Moq;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using ScientificReportData.Models;
using ScientificReportData.Repositories;
using ScientificReportServices;

namespace Tests
{
    [TestFixture]
    public class ReportServiceTests
    {
        [Test]
        public void ReportServiceTest_CreateReport()
        {
            //Arrange

            List<Author> authors1 = new List<Author>();
            var author1 = new Author
            {
                Name = "Bogdan",
                Id = 1,
            };
            authors1.Add(author1);
            var dw = new DepartmentWork
            {
                Id = 1,
                Authors = authors1,
                Category = "Math",
                Content = "Algebra",
                Intro = "hello",
                Topic = "Equations"

            };
            var testList = new List<DepartmentWork>() { dw };

            var dbSetMock1 = new Mock<DbSet<DepartmentWork>>();
            dbSetMock1.As<IQueryable<DepartmentWork>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock1.As<IQueryable<DepartmentWork>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock1.As<IQueryable<DepartmentWork>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock1.As<IQueryable<DepartmentWork>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());

            var context1 = new Mock<DbContext>();
            context1.Setup(x => x.Set<DepartmentWork>()).Returns(dbSetMock1.Object);

            // Act
            var repository1 = new Repository<DepartmentWork, int>(context1.Object);
            var result1 = repository1.GetAll();

            List<Author> authors2 = new List<Author>();
            var author2 = new Author
            {
                Name = "Bogdan",
                Id = 1,
            };
            authors2.Add(author2);
            var gr = new Grant
            {
                Id = 1,
                Participants = authors2,
                Name = "Newton",
                Description = "Algebra",
            };
            var testList2 = new List<Grant>() { gr };

            var dbSetMock2 = new Mock<DbSet<Author>>();
            dbSetMock2.As<IQueryable<Author>>().Setup(x => x.Provider).Returns(authors2.AsQueryable().Provider);
            dbSetMock2.As<IQueryable<Author>>().Setup(x => x.Expression).Returns(authors2.AsQueryable().Expression);
            dbSetMock2.As<IQueryable<Author>>().Setup(x => x.ElementType).Returns(authors2.AsQueryable().ElementType);
            dbSetMock2.As<IQueryable<Author>>().Setup(x => x.GetEnumerator()).Returns(authors2.AsQueryable().GetEnumerator());

            var context2 = new Mock<DbContext>();
            context2.Setup(x => x.Set<Author>()).Returns(dbSetMock2.Object);

            // Act
            var repository2 = new Repository<Author, int>(context2.Object);
            var result2 = repository2.GetAll();

            var repo = new ScientificReportData.Models.Report
            {
                Id = 1,
                Date = new DateTime(1999, 12, 1),
                DepartmentWork = "AMI",
                Conferences = "none",
                Contetnt = "smth",
                Intro = "Begin"
            };
            List<Report> reports = new List<Report>();
            reports.Add(repo);

            List<Author> authors = new List<Author>();
            var author = new Author
            {
                Name = "Bogdan",
                Id = 1,
            };
            authors.Add(author);

            var publication = new Publication
            {
                Status = "prove",
                Authors = authors,
                Id = 1,
                Date = new DateTime(2009, 12, 1),
                Topic = "sfs",
                Type = "math"
            };
            List<Publication> publications = new List<Publication>();
            publications.Add(publication);

            var internship = new Internship
            {
                Name = "mine",
                Id = 1
            };

            List<Internship> internships = new List<Internship>();
            internships.Add(internship);

            var user = new ScientificReportData.Models.User
            {
                Name = "ME",
                Birthdate = new DateTime(1992, 1, 12),
                DegreeLevel = "BACHELOR",
                DegreeDate = new DateTime(2010, 1, 12),
                GraduationDate = new DateTime(2011, 1, 12),
                Title = "124rs",
                TitleDate = new DateTime(2016, 1, 12),
                Faculty = "AMI",
                Department = "AM",
                IsAdmin = false,
                IsApproved = true,
                Reports = reports,
                Publications = publications,
                Internships = internships,
            };

            var testarray = new List<User>() {user};

            //var testarray = new List<Publication>() { pb };

            var intro = new StringBuilder();
            intro.Append(
                    $"Рік народження: {user.Birthdate.Year}")
                .Append(Environment.NewLine)
                .Append($"Рік закінчення ВНЗ {user.GraduationDate}").Append(Environment.NewLine)
                .Append($"Науковий ступінь: {user.DegreeLevel} рік захисту {user.DegreeDate.Year}")
                .Append(Environment.NewLine)
                .Append($"Вчене звання: {user.Title} рік присвоєння {user.TitleDate.Year}"
                );

            var userAsAuthor = repository2.GetAll().FirstOrDefault(a => a.Name == user.Name);
            var works = repository1.GetAll().Where(w => w.Authors.Contains(userAsAuthor));
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

            var report = new Report
            {
                Date = DateTime.Today.Date,
                Intro = intro.ToString(),
                DepartmentWork = section.ToString(),

            };
            var testarray1 = new List<Report>() { report };

            var dbSetMock = new Mock<DbSet<Report>>();
            dbSetMock.As<IQueryable<Report>>().Setup(x => x.Provider).Returns(testarray1.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Report>>().Setup(x => x.Expression).Returns(testarray1.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Report>>().Setup(x => x.ElementType).Returns(testarray1.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Report>>().Setup(x => x.GetEnumerator()).Returns(testarray1.AsQueryable().GetEnumerator());

            var context = new Mock<DbContext>();
            context.Setup(x => x.Set<Report>()).Returns(dbSetMock.Object);

            // Act
            var repository = new Repository<Report, int>(context.Object);
            var result = repository.GetAll();

            // Assert
            Assert.AreEqual(report, result.ToList()[0]);
        }

        [Test]
        public void ReportServiceTest_CreateViewModel()
        {
            


            List<Author> authors = new List<Author>();
            var author = new Author
            {
                Name = "Began",
                Id = 1,
            };
            authors.Add(author);
            var pb = new Publication()
            {
                Id = 1,
                Authors = authors,
                Topic = "Newton",
                Status = "closed",
                Type = "math",
                Date = new DateTime(2019, 8, 1),
            };
            var testarray = new List<Publication>() { pb };


            var dbSetMock = new Mock<DbSet<Publication>>();
            dbSetMock.As<IQueryable<Publication>>().Setup(x => x.Provider).Returns(testarray.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Publication>>().Setup(x => x.Expression).Returns(testarray.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Publication>>().Setup(x => x.ElementType).Returns(testarray.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Publication>>().Setup(x => x.GetEnumerator()).Returns(testarray.AsQueryable().GetEnumerator());

            var context = new Mock<DbContext>();
            context.Setup(x => x.Set<Publication>()).Returns(dbSetMock.Object);

            // Act
            var repository = new Repository<Publication, int>(context.Object);
            var result = repository.GetAll();

            //Arrange

            var gr = new Grant
            {
                Id = 1,
                Participants = authors,
                Name = "Newton",
                Description = "Algebra",
            };
            var testList = new List<Grant>() { gr };

            var dbSetMock1 = new Mock<DbSet<Grant>>();
            dbSetMock1.As<IQueryable<Grant>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock1.As<IQueryable<Grant>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock1.As<IQueryable<Grant>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock1.As<IQueryable<Grant>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());

            var context1 = new Mock<DbContext>();
            context1.Setup(x => x.Set<Grant>()).Returns(dbSetMock1.Object);

            // Act
            var repository1 = new Repository<Grant, int>(context1.Object);
            var result1 = repository1.GetAll();

            var dw = new DepartmentWork
            {
                Id = 1,
                Authors = authors,
                Category = "Math",
                Content = "Algebra",
                Intro = "hello",
                Topic = "Equations"

            };
            var testList1= new List<DepartmentWork>() { dw };

            var dbSetMock2 = new Mock<DbSet<DepartmentWork>>();
            dbSetMock2.As<IQueryable<DepartmentWork>>().Setup(x => x.Provider).Returns(testList1.AsQueryable().Provider);
            dbSetMock2.As<IQueryable<DepartmentWork>>().Setup(x => x.Expression).Returns(testList1.AsQueryable().Expression);
            dbSetMock2.As<IQueryable<DepartmentWork>>().Setup(x => x.ElementType).Returns(testList1.AsQueryable().ElementType);
            dbSetMock2.As<IQueryable<DepartmentWork>>().Setup(x => x.GetEnumerator()).Returns(testList1.AsQueryable().GetEnumerator());

            var context2 = new Mock<DbContext>();
            context2.Setup(x => x.Set<DepartmentWork>()).Returns(dbSetMock2.Object);

            // Act
            var repository2 = new Repository<DepartmentWork, int>(context2.Object);
            var result2 = repository2.GetAll();

            var Conf = new Conference
            {
                Date = new DateTime(2008, 3, 1, 7, 0, 0),
                Id = 1,
                Description = "sad",
                ImgPath = "sss",
                Likes = 145,
                Title = "Math",
                Watches = 300,
                Participants = authors,
            };

            var testList2 = new List<Conference>() {Conf};

            var dbSetMock3 = new Mock<DbSet<Conference>>();
            dbSetMock3.As<IQueryable<Conference>>().Setup(x => x.Provider).Returns(testList2.AsQueryable().Provider);
            dbSetMock3.As<IQueryable<Conference>>().Setup(x => x.Expression).Returns(testList2.AsQueryable().Expression);
            dbSetMock3.As<IQueryable<Conference>>().Setup(x => x.ElementType).Returns(testList2.AsQueryable().ElementType);
            dbSetMock3.As<IQueryable<Conference>>().Setup(x => x.GetEnumerator()).Returns(testList2.AsQueryable().GetEnumerator());

            var context3 = new Mock<DbContext>();
            context3.Setup(x => x.Set<Conference>()).Returns(dbSetMock3.Object);

            // Act
            var repository3 = new Repository<Conference, int>(context3.Object);
            var result3 = repository3.GetAll();

            var repo = new ScientificReportData.Models.Report
            {
                Id = 1,
                Date = new DateTime(1999, 12, 1),
                DepartmentWork = "AMI",
                Conferences = "none",
                Contetnt = "smth",
                Intro = "Begin"
            };
            List<Report> reports = new List<Report>();
            reports.Add(repo);

            authors.Add(author);

            var publication = new Publication
            {
                Status = "prove",
                Authors = authors,
                Id = 1,
                Date = new DateTime(2009, 12, 1),
                Topic = "sfs",
                Type = "math"
            };
            List<Publication> publications = new List<Publication>();
            publications.Add(publication);

            var internship = new Internship
            {
                Name = "mine",
                Id = 1
            };

            List<Internship> internships = new List<Internship>();
            internships.Add(internship);

            var user = new ScientificReportData.Models.User
            {
                Name = "ME",
                Birthdate = new DateTime(1992, 1, 12),
                DegreeLevel = "BACHELOR",
                DegreeDate = new DateTime(2010, 1, 12),
                GraduationDate = new DateTime(2011, 1, 12),
                Title = "124rs",
                TitleDate = new DateTime(2016, 1, 12),
                Faculty = "AMI",
                Department = "AM",
                IsAdmin = false,
                IsApproved = true,
                Reports = reports,
                Publications = publications,
                Internships = internships,
            };

            var Curuser = new ScientificReportData.Models.User
            {
                Name = "NOTME",
                Birthdate = new DateTime(1992, 1, 12),
                DegreeLevel = "BACHELOR",
                DegreeDate = new DateTime(2010, 1, 12),
                GraduationDate = new DateTime(2011, 1, 12),
                Title = "124rs",
                TitleDate = new DateTime(2016, 1, 12),
                Faculty = "AMI",
                Department = "AM",
                IsAdmin = false,
                IsApproved = true,
                Reports = reports,
                Publications = publications,
                Internships = internships,
            };

            var publicationres = result.Where(p => p.Authors.Any(a => a.Name == user.Name))?.ToList();
            var grantsres = result1.Where(p => p.Participants.Any(a => a.Name == user.Name))?.ToList();
            var depWorksres =result2.Where(p => p.Authors.Any(a => a.Name == user.Name))?.ToList();
            var conferencesres = result3.Where(p => p.Participants.Any(a => a.Name == user.Name))?.ToList();

            var resulting = new ReportViewModel
            {
                User = user,
                Publications = publicationres ?? new List<Publication>(),
                DepartmentWorks = depWorksres ?? new List<DepartmentWork>(),
                Conferences = conferencesres ?? new List<Conference>(),
                Grants = grantsres ?? new List<Grant>()
            };

            using (var mack = AutoMock.GetLoose())
            {
                //Arrange
                mack.Mock<IReportService>()
                    .Setup(x => x.CreateViewModel(user,DateTime.MinValue,DateTime.MaxValue ))
                    .Returns(GetSampleViewModel(resulting));
                //Act
                var cls = mack.Create<IReportService>();

                var expected = GetSampleViewModel(resulting);

                var actual = cls.CreateViewModel(user,DateTime.MinValue,DateTime.MaxValue );
                //Assert
                Assert.AreEqual(actual,expected);
            };
        }

        public ReportViewModel GetSampleViewModel(ReportViewModel resulting)
        {
            return resulting;
        }
    }


}