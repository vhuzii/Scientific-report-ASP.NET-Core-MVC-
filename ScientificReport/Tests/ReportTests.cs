using Autofac.Extras.Moq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ScientificReport.Data.DataAccess;
using ScientificReportData.Models;
using ScientificReportServices;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class ReportTests
    {
        // TODO: Feel free to write report tests here
        public static Conference[] temp = new Conference[2];

        public static Conference[] setSample()
        {
            List<Author> temp1 = new List<Author>();
            var author = new Author
            {
                Name = "dad",
                Id = 1,
            };
            temp1.Add(author);
            var ex = new Conference
            {
                Date = new DateTime(2008, 3, 1, 7, 0, 0),
                Id = 1,
                Description = "sad",
                ImgPath = "sss",
                Likes = 145,
                Title = "Math",
                Watches = 300,
                Participants = temp1,
            };
            temp[0] = ex;
            var ex1 = new Conference
            {
                Date = DateTime.Now,
                Id = 2,
                Description = "sad1",
                ImgPath = "sss1",
                Likes = 1415,
                Title = "Math1",
                Watches = 3010,
                Participants = temp1,
            };
            temp[1] = ex;
            return temp;
        }
        [Test]
        public void ConferenceServiceTest_getAll()
        {
            using (var mack = AutoMock.GetLoose())
            {
                //Arrange
                mack.Mock<IConferenceService>()
                    .Setup(x => x.getAll())
                    .Returns(GetSampleConferences());
                //Act
                var cls = mack.Create<IConferenceService>();

                var expected = GetSampleConferences();

                var actual = cls.getAll();
                //Assert
                foreach (Conference a in expected)
                    foreach (Conference b in actual)
                        Assert.AreEqual(a.Id, b.Id);
            };
        }

        private IEnumerable<Conference> GetSampleConferences()
        {
            Conference[] temp = new Conference[1];
            List<Author> temp1 = new List<Author>();

            var author = new Author
            {
                Name = "dad",
                Id = 1,
            };
            temp1.Add(author);
            var ex = new Conference
            {
                Date = DateTime.Now,
                Id = 1,
                Description = "sad",
                ImgPath = "sss",
                Likes = 145,
                Title = "Math",
                Watches = 300,
                Participants = temp1,
            };
            temp[0] = ex;
            return temp;
        }

        [Test]
        public void ConferenceServiceTest_getbyId()
        {
            using (var mack = AutoMock.GetLoose())
            {
                //Arrange
                mack.Mock<IConferenceService>()
                    .Setup(x => x.getById(1))
                    .Returns(GetSampleConference(1));
                //Act
                var cls = mack.Create<IConferenceService>();

                var expected = GetSampleConference(1);

                var actual = cls.getById(1);
                //Assert


                Assert.AreEqual(actual.Likes, expected.Likes);
            };
        }

        private Conference GetSampleConference(int id)
        {
            Conference[] temp = setSample();

            foreach (Conference a in temp)
            {
                if (a.Id == id)
                    return a;
            }
            return temp[temp.Length - 1];
        }


        [Test]
        public void ConferenceServiceTest_getDatebyId()
        {
            using (var mack = AutoMock.GetLoose())
            {
                //Arrange
                mack.Mock<IConferenceService>()
                    .Setup(x => x.getDateById(1))
                    .Returns(GetDatebyID(1));
                //Act
                var cls = mack.Create<IConferenceService>();

                var expected = GetDatebyID(1);

                var actual = cls.getDateById(1);
                //Assert

                Assert.AreEqual(actual, expected);
            };
        }

        private DateTime GetDatebyID(int a)
        {
            Conference[] temp = setSample();
            foreach (Conference conf in temp)
            {
                if (conf.Id == a)
                    return conf.Date;
            }
            return temp[temp.Length - 1].Date;
        }


        [Test]
        public void ConferenceServiceTest_getDescriptionbyId()
        {

            using (var mack = AutoMock.GetLoose())
            {
                //Arrange
                mack.Mock<IConferenceService>()
                    .Setup(x => x.getDescriptionById(1))
                    .Returns(GetDescriptionbyID(1));
                //Act
                var cls = mack.Create<IConferenceService>();

                var expected = GetDescriptionbyID(1);

                var actual = cls.getDescriptionById(1);
                //Assert

                Assert.AreEqual(actual, expected);
            };
        }

        private string GetDescriptionbyID(int a)
        {
            Conference[] temp = setSample();
            foreach (Conference conf in temp)
            {
                if (conf.Id == a)
                    return conf.Description;
            }
            return temp[temp.Length - 1].Description;
        }

        [Test]
        public void ConferenceServiceTest_getImgPathbyId()
        {
            using (var mack = AutoMock.GetLoose())
            {
                //Arrange
                mack.Mock<IConferenceService>()
                .Setup(x => x.getImgPathById(1))
                .Returns(GetPathbyID(1));
                //Act
                var cls = mack.Create<IConferenceService>();

                var expected = GetPathbyID(1);

                var actual = cls.getImgPathById(1);
                //Assert

                Assert.AreEqual(actual, expected);
            }

        }

        private string GetPathbyID(int a)
        {
            Conference[] temp = setSample();
            foreach (Conference conf in temp)
            {
                if (conf.Id == a)
                    return conf.ImgPath;
            }
            return temp[temp.Length - 1].ImgPath;
        }

        [Test]
        public void ConferenceServiceTest_getLikesbyId()
        {
            using (var mack = AutoMock.GetLoose())
            {
                //Arrange
                mack.Mock<IConferenceService>()
                .Setup(x => x.getLikesById(1))
                .Returns(GetlikesbyID(1));
                //Act
                var cls = mack.Create<IConferenceService>();

                var expected = GetlikesbyID(1);

                var actual = cls.getLikesById(1);
                //Assert

                Assert.AreEqual(actual, expected);
            }
        }

        private int GetlikesbyID(int a)
        {
            Conference[] temp = setSample();
            foreach (Conference conf in temp)
            {
                if (conf.Id == a)
                    return conf.Likes;
            }
            return temp[temp.Length - 1].Likes;
        }

        [Test]
        public void ConferenceServiceTest_getWatchesbyId()
        {
            using (var mack = AutoMock.GetLoose())
            {
                //Arrange
                mack.Mock<IConferenceService>()
                .Setup(x => x.getWatchesById(1))
                .Returns(GetWatchesbyID(1));
                //Act
                var cls = mack.Create<IConferenceService>();

                var expected = GetWatchesbyID(1);

                var actual = cls.getWatchesById(1);
                //Assert

                Assert.AreEqual(actual, expected);
            }
        }

        private int GetWatchesbyID(int a)
        {
            Conference[] temp = setSample();
            foreach (Conference conf in temp)
            {
                if (conf.Id == a)
                    return conf.Watches;
            }
            return temp[temp.Length - 1].Watches;
        }

        [Test]
        public void ConferenceServiceTest_getTitlebyId()
        {
            using (var mack = AutoMock.GetLoose())
            {
                //Arrange
                mack.Mock<IConferenceService>()
                .Setup(x => x.getTitleById(1))
                .Returns(GetTitlebyID(1));
                //Act
                var cls = mack.Create<IConferenceService>();

                var expected = GetTitlebyID(1);

                var actual = cls.getTitleById(1);
                //Assert

                Assert.AreEqual(actual, expected);
            }
        }

        private string GetTitlebyID(int a)
        {
            Conference[] temp = setSample();
            foreach (Conference conf in temp)
            {
                if (conf.Id == a)
                    return conf.Title;
            }
            return temp[temp.Length - 1].Title;
        }
    }
}