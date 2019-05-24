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
    class UserConferenceServiceTests
    {
        [Test]
        public void UserConferenceServiceTest_getAll()
        {
            var userconf = new UserConference()
            {
                Id  =1,
                ConferenceId = 1,
                UserId = "sds"
            };

            var testList = new List<UserConference>() { userconf };

            var dbSetMock = new Mock<DbSet<UserConference>>();
            dbSetMock.As<IQueryable<UserConference>>().Setup(x => x.Provider).Returns(testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<UserConference>>().Setup(x => x.Expression).Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<UserConference>>().Setup(x => x.ElementType).Returns(testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<UserConference>>().Setup(x => x.GetEnumerator()).Returns(testList.AsQueryable().GetEnumerator());

            var context = new Mock<DbContext>();
            context.Setup(x => x.Set<UserConference>()).Returns(dbSetMock.Object);

            // Act
            var repository = new Repository<UserConference, int>(context.Object);
            var result = repository.GetAll();

            // Assert
            Assert.AreEqual(testList, result.ToList());
        }

        [Test]
        public void UserConferenceServiceTest_getbyId()
        {
            using (var mack = AutoMock.GetLoose())
            {
                //Arrange
                mack.Mock<IUserConferenceService>()
                    .Setup(x => x.getById(1))
                    .Returns(GetSampleConferences(1));
                //Act
                var cls = mack.Create<IUserConferenceService>();

                var expected = GetSampleConferences(1);

                var actual = cls.getById(1);
                //Assert
                Assert.AreEqual(expected.Id, actual.Id);
            };
        }

        public UserConference GetSampleConferences(int id)
        {
            List<UserConference> list = new List<UserConference>();
            var userconf = new UserConference()
            {
                Id = 1,
                ConferenceId = 1,
                UserId = "sds"
            };
            list.Add(userconf);
            var userconf2 = new UserConference()
            {
                Id = 2,
                ConferenceId = 1,
                UserId = "sds1"
            };
            list.Add(userconf2);
            UserConference result = null;
            foreach (UserConference a in list)
            {
                if (a.Id == id)
                    result = a;
            }
            return result;
        }

    }
}
