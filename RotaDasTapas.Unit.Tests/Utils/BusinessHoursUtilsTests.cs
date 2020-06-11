using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotaDasTapas.Constants;
using RotaDasTapas.Models.Response;
using RotaDasTapas.Utils;

namespace RotaDasTapas.Unit.Tests.Utils
{
    [TestClass]
    public class BusinessHoursUtilsTests
    {
        private readonly IBusinessHoursUtils _businessHoursUtils;

        public BusinessHoursUtilsTests()
        {
            _businessHoursUtils = new BusinessHoursHoursUtils();
        }

        [TestMethod]
        public void GetStatus_ValidBusinessHours_ReturnsClosingSoon()
        {
            //arrange
            var sundayMorning = new DateTime(2020, 6, 7, 15, 45, 00);
            var businessHours = "10:45,16:00;0,0";
            var expected = new Schedule
            {
                Hours = "10:45-16:00",
                Status = BusinessHoursConstants.ClosingSoon
            };

            //act
            _businessHoursUtils.Init(businessHours, sundayMorning);
            var result = _businessHoursUtils.GetStatus();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Status, result);
        }

        [TestMethod]
        public void GetCurrentSchedule_ValidBusinessHours_ReturnsCurrentBusinessHours()
        {
            //arrange
            var sundayMorning = new DateTime(2020, 6, 7, 15, 45, 00);
            var businessHours = "10:45,16:00;0,0";
            var expected = new Schedule
            {
                Hours = "10:45-16:00"
            };

            //act
            _businessHoursUtils.Init(businessHours, sundayMorning);
            var result = _businessHoursUtils.GetCurrentSchedule();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Hours, result);
        }

        [TestMethod]
        public void GetStatus_ValidBusinessHours_ReturnsClosed()
        {
            //arrange
            var sundayMorning = new DateTime(2019, 12, 22, 11, 00, 00);
            var businessHours = "08:00,24:00;3,3";

            var expected = new Schedule
            {
                Status = BusinessHoursConstants.ClosedToday
            };

            //act
            _businessHoursUtils.Init(businessHours, sundayMorning);
            var result = _businessHoursUtils.GetStatus();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Status, result);
        }

        [TestMethod]
        public void GetCurrentSchedule_ValidBusinessHours_ReturnsEmptyd()
        {
            //arrange
            var sundayMorning = new DateTime(2019, 12, 22, 11, 00, 00);
            var businessHours = "08:00,24:00;3,3";

            var expected = new Schedule
            {
                Hours = string.Empty
            };

            //act
            _businessHoursUtils.Init(businessHours, sundayMorning);
            var result = _businessHoursUtils.GetCurrentSchedule();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Hours, result);
        }

        [TestMethod]
        public void GetStatus_ValidBusinessHours_ReturnsOpen()
        {
            //arrange
            var sundayMorning = new DateTime(2019, 12, 22, 11, 00, 00);
            var businessHours = "08:00,24:00;0,6";

            var expected = new Schedule
            {
                Status = BusinessHoursConstants.Open
            };

            //act
            _businessHoursUtils.Init(businessHours, sundayMorning);
            var result = _businessHoursUtils.GetStatus();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Status, result);
        }

        [TestMethod]
        public void GetCurrentSchedule_ValidBusinessHours_ReturnsOpen()
        {
            //arrange
            var sundayMorning = new DateTime(2019, 12, 22, 11, 00, 00);
            var businessHours = "08:00,24:00;0,6";

            var expected = new Schedule
            {
                Hours = "08:00-00:00"
            };

            //act
            _businessHoursUtils.Init(businessHours, sundayMorning);
            var result = _businessHoursUtils.GetCurrentSchedule();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Hours, result);
        }

        [TestMethod]
        public void GetStatus_InvalidBusinessHours_ReturnsEmpty()
        {
            //arrange
            var businessHours = "08:00,24:00;7,7";
            var sundayMorning = new DateTime(2019, 12, 22, 11, 00, 00);

            //act
            _businessHoursUtils.Init(businessHours, sundayMorning);
            var result = _businessHoursUtils.GetStatus();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void GetCurrentSchedule_InvalidBusinessHours_ReturnsEmpty()
        {
            //arrange
            var businessHours = "08:00,24:00;7,7";
            var sundayMorning = new DateTime(2019, 12, 22, 11, 00, 00);

            //act
            _businessHoursUtils.Init(businessHours, sundayMorning);
            var result = _businessHoursUtils.GetCurrentSchedule();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void GetCurrentSchedule_NullBusinessHours_ReturnsEmpty()
        {
            //arrange
            string businessHours = null;
            var sundayMorning = new DateTime(2019, 12, 22, 11, 00, 00);

            //act
            _businessHoursUtils.Init(businessHours, sundayMorning);
            var result = _businessHoursUtils.GetCurrentSchedule();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void GetCurrentSchedule_ValidBusinessHours_ReturnsBusinessHours()
        {
            //arrange
            var sundayMorning = new DateTime(2019, 12, 22, 11, 45, 00);
            var businessHours = "08:00,12:00;0,6";

            var expected = new Schedule
            {
                Hours = "08:00-12:00"
            };

            //act
            _businessHoursUtils.Init(businessHours, sundayMorning);
            var result = _businessHoursUtils.GetCurrentSchedule();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Hours, result);
        }

        [TestMethod]
        public void GetStatus_ValidBusinessHours_ReturnsOpeningSoonAndIsEnable()
        {
            //arrange
            var sundayMorning = new DateTime(2020, 6, 7, 11, 00, 00);
            const string businessHours = "11:15,24:00;0,0";

            var expected = new Schedule
            {
                Hours = "11:15-00:00",
                Status = BusinessHoursConstants.OpeningSoon
            };

            //act
            _businessHoursUtils.Init(businessHours, sundayMorning);
            var result = _businessHoursUtils.GetStatus();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Status, result);
        }
    }
}