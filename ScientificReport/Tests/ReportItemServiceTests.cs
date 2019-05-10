using System;
using Autofac.Extras.Moq;
using NUnit.Framework;
using ScientificReportData;
using ScientificReportData.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using ScientificReportData.Repositories;

namespace Tests
{
    [TestFixture]
    public class ReportItemServiceTests
    {
        [Test]
        public void ReportItemServiceTest_AddDepartmentWork()
        {
            //Arrange
            List<Author> authors = new List<Author>();
            var author = new Author
            {
                Name = "Bogdan",
                Id = 1,
            };
            authors.Add(author);
            var dw = new DepartmentWork
            {
                Id = 1,
                Authors = authors,
                Category = "Math",
                Content = "Algebra",
                Intro = "hello",
                Topic = "Equations"

            };
            var testList = new List<DepartmentWork>() { dw };

            var dbSetMock = new Mock<DbSet<DepartmentWork>>();
            dbSetMock.As<IQueryable<DepartmentWork>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<DepartmentWork>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<DepartmentWork>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<DepartmentWork>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());

            var context = new Mock<DbContext>();
            context.Setup(x => x.Set<DepartmentWork>()).Returns(dbSetMock.Object);

            // Act
            var repository = new Repository<DepartmentWork, int>(context.Object);
            var result = repository.GetAll();

            // Assert
            Assert.AreEqual(dw, result.ToList()[0]);
        }

        [Test]
        public void ReportItemServiceTest_AddGrant()
        {
            //Arrange
            List<Author> authors = new List<Author>();
            var author = new Author
            {
                Name = "Bogdan",
                Id = 1,
            };
            authors.Add(author);
            var gr = new Grant
            {
                Id = 1,
                Participants = authors,
                Name = "Newton",
                Description = "Algebra",
            };
            var testList = new List<Grant>() { gr };

            var dbSetMock = new Mock<DbSet<Grant>>();
            dbSetMock.As<IQueryable<Grant>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Grant>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Grant>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Grant>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());

            var context = new Mock<DbContext>();
            context.Setup(x => x.Set<Grant>()).Returns(dbSetMock.Object);

            // Act
            var repository = new Repository<Grant, int>(context.Object);
            var result = repository.GetAll();

            // Assert
            Assert.AreEqual(gr, result.ToList()[0]);
        }

        [Test]
        public void ReportItemServiceTest_AddAuthor()
        {
            //Arrange
            List<Author> authors = new List<Author>();
            var author = new Author
            {
                Name = "Bogdan",
                Id = 1,
            };
            authors.Add(author);
            var gr = new Grant
            {
                Id = 1,
                Participants = authors,
                Name = "Newton",
                Description = "Algebra",
            };
            var testList = new List<Grant>() { gr };

            var dbSetMock = new Mock<DbSet<Author>>();
            dbSetMock.As<IQueryable<Author>>().Setup(x => x.Provider).Returns(authors.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Author>>().Setup(x => x.Expression).Returns(authors.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Author>>().Setup(x => x.ElementType).Returns(authors.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Author>>().Setup(x => x.GetEnumerator()).Returns(authors.AsQueryable().GetEnumerator());

            var context = new Mock<DbContext>();
            context.Setup(x => x.Set<Author>()).Returns(dbSetMock.Object);

            // Act
            var repository = new Repository<Author, int>(context.Object);
            var result = repository.GetAll();

            // Assert
            Assert.AreEqual(author, result.ToList()[0]);
        }

        [Test]
        public void ReportItemServiceTest_AddPublication()
        {
            //Arrange
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
                Date = new DateTime(2019,8,1),
            };
            var testarray = new List<Publication>() {pb};


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

            // Assert
            Assert.AreEqual(pb, result.ToList()[0]);
        }

    }
}