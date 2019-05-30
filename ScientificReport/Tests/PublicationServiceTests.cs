using System;
using System.Collections.Generic;
using Autofac.Extras.Moq;
using NUnit.Framework;
using ScientificReportData.Models;
using ScientificReportServices;
using ScientificReportServices.Interfaces;

namespace Tests
{
    [TestFixture]
    public class PublicationServiceTests
    {

        [Test]
        public void PublicationServiceTest_AddPublication()
        {
            using (var mack = AutoMock.GetLoose())
            {
                //Arrange
                var model = new CreatePublicationModel
                {
                    Date = new DateTime(2019, 1, 1),
                    Authors = "Bogdan Volodymyr Andrainna Bogdan Volodymyr",
                    Status = "closed",
                    Topic = "Report",

                };

                mack.Mock<IPublicationService>()
                    .Setup(x => x.AddPublication(model))
                    .Returns(addpublication(model));
                //Act
                var cls = mack.Create<IPublicationService>();

                var expected = addpublication(model);

                var actual = cls.AddPublication(model);
                //Assert
                Assert.AreEqual(expected.Id,actual.Id);
            };
        }

        public Publication addpublication(CreatePublicationModel model)
        {
            
            var authorNames = model.Authors.Split(" ");
            List<Author> authors = new List<Author>();
            foreach (var name in authorNames)
            {
                var author = new Author { Name = name };
                authors.Add(author);
            }
            var publ = new Publication
            {
                Date = model.Date,
                Authors = authors.ToArray(),
                Status = model.Status,
                Topic = model.Topic,
            };

            return publ;
        }
    }
}