using Autofac.Extras.Moq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ScientificReport.Data.DataAccess;
using ScientificReportData.Models;
using ScientificReportServices;
using System;
using System.Collections;
using System.Collections.Generic;
using ScientificReportData;
using ScientificReportData.Interfaces;
using ScientificReportData.Repositories;
using System.Linq;
using Moq;

namespace Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        [Test]
        public void UserServiceTest_getAll()
        {
            // Arrange
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
            var testList = new List<User>() { user };

            var dbSetMock = new Mock<DbSet<User>>();
            dbSetMock.As<IQueryable<User>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<User>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<User>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<User>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());

            var context = new Mock<DbContext>();
            context.Setup(x => x.Set<User>()).Returns(dbSetMock.Object);

            // Act
            var repository = new Repository<User,string>(context.Object);
            var result = repository.GetAll();

            // Assert
            Assert.AreEqual(testList, result.ToList());
        }
    }
}