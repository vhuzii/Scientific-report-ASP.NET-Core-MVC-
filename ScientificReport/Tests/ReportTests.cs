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
        private readonly IConferenceService conferenceService;
        // TODO: Feel free to write report tests here
        [Test]
        public void ConferenceServiceTest_getAll()
        {
            //Arrange
            var options = new DbContextOptions<ReportContext>();
            var report = new ReportContext(options);
            var service = new ConferenceService(report);

            //Act
            var result = service.getAll();

            //Assert
            Assert.IsInstanceOf(typeof(IEnumerable<Conference>), result);
        }

        [Test]
        public void ConferenceServiceTest_getbyId()
        {

            //Act
            var result = conferenceService.getById(21);

            //Assert
            Assert.IsInstanceOf(typeof(Conference), result);
        }

        [Test]
        public void ConferenceServiceTest_getbyId_ResultTrue()
        {
            //Arrange


            //Act
            var result = conferenceService.getById(21);
            bool temp = false;
            if (result.Likes == 145)
                temp = true;

            //Assert
            Assert.IsTrue(temp);
        }

        [Test]
        public void ConferenceServiceTest_getDatebyId()
        {

            //Act
            var result = conferenceService.getDateById(21);

            //Assert
            Assert.Equals("2019-04-05 15:57:23.9800000", result);
        }


        [Test]
        public void ConferenceServiceTest_getDescriptionbyId()
        {

            //Act
            var result = conferenceService.getDescriptionById(21);

            //Assert
            Assert.Equals("The goal of this conference is to foster collaboration between applied" +
                " mathematicians working in related fields at various institutions.\nMain topics:" +
                " Boundary Integral Equation Methods, Boundary Element Methods, Finite Element Methods" +
                "Finite Difference Methods for Direct and Inverse Problems; Newton" +
                " - type Methods for Non - Linear Operator Equations and related Directions" +
                " of Applied and Computational Mathematics; Problems in Computer Science.", result);
        }

        [Test]
        public void ConferenceServiceTest_getImgPathbyId()
        {

            //Act
            var result = conferenceService.getImgPathById(21);

            //Assert
            Assert.Equals("/img/Conferences/2.jpg", result);
        }

        [Test]
        public void ConferenceServiceTest_getLikesbyId()
        {

            //Act
            var result = conferenceService.getLikesById(21);

            //Assert
            Assert.Equals(145, result);
        }

        [Test]
        public void ConferenceServiceTest_getWatchesbyId()
        {

            //Act
            var result = conferenceService.getWatchesById(21);

            //Assert
            Assert.Equals(301, result);
        }

        [Test]
        public void ConferenceServiceTest_getTitlebyId()
        {

            //Act
            var result = conferenceService.getTitleById(1);

            //Assert
            Assert.Equals("Conference on Applied Mathimatics", result);
        }

    }
}