using System;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RotaDasTapas.Constants;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Models.Models;
using RotaDasTapas.Models.Response;
using RotaDasTapas.Profiles.ValueResolver;

namespace RotaDasTapas.Unit.Tests.Profiles.ValueResolver
{
    [TestClass]
    public class BusinessHoursResolverTests
    {
        private readonly BusinessHoursResolver _businessHoursResolver;
        private readonly Mock<IDateTimeWrapper> _dateTimeWrapperMock;
        private readonly ResolutionContext _context;
        private readonly Tapa _destination;
        private readonly Schedule _destMember;

        public BusinessHoursResolverTests()
        {
            _destination = new Tapa();
            _destMember = new Schedule();
            _dateTimeWrapperMock = new Mock<IDateTimeWrapper>();
            _businessHoursResolver = new BusinessHoursResolver(_dateTimeWrapperMock.Object);
            var runtimeMapperMock = new Mock<IRuntimeMapper>();
            var mappingOperationOptions = new Mock<IMappingOperationOptions>();
            _context = new ResolutionContext(mappingOperationOptions.Object, runtimeMapperMock.Object);
        }

        [TestMethod]
        public void Resolve_NullBusinessHours_ReturnsEmptyString()
        {
            //arrange
            _dateTimeWrapperMock.Setup(x => x.Now).Returns(new DateTime(1993, 1, 1));
            var tapaDto = new TapaDto
            {
                Schedule = null
            };

            //act
            var result = _businessHoursResolver.Resolve(tapaDto, _destination, _destMember, _context);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result.Hours);
            Assert.AreEqual(string.Empty, result.Status);
        }

        [TestMethod]
        public void Resolve_InvalidBusinessHours_ReturnsEmpty()
        {
            //arrange
            _dateTimeWrapperMock.Setup(x => x.Now).Returns(new DateTime(1993, 1, 1));
            var tapaDto = new TapaDto
            {
                Schedule = "08:00,24:00;7,7"
            };

            //act
            var result = _businessHoursResolver.Resolve(tapaDto, _destination, _destMember, _context);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result.Hours);
            Assert.AreEqual(string.Empty, result.Status);
        }

        [TestMethod]
        public void Resolve_ValidBusinessHours_ReturnsOpenAndEnable()
        {
            //arrange
            var sundayMorning = new DateTime(2019, 12, 22, 11, 00, 00);
            _dateTimeWrapperMock.Setup(x => x.Now).Returns(sundayMorning);
            var tapaDto = new TapaDto
            {
                Schedule = "08:00,24:00;0,6"
            };

            var expected = new Schedule
            {
                Hours = "08:00-00:00",
                Status = BusinessHoursConstants.Open
            };

            //act
            var result = _businessHoursResolver.Resolve(tapaDto, _destination, _destMember, _context);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Hours, result.Hours);
            Assert.AreEqual(expected.Status, result.Status);
            Assert.IsFalse(result.Disable);
        }

        [TestMethod]
        public void Resolve_ValidBusinessHours_ReturnsClosedAndIsNotEnable()
        {
            //arrange
            var sundayMorning = new DateTime(2019, 12, 22, 11, 00, 00);
            _dateTimeWrapperMock.Setup(x => x.Now).Returns(sundayMorning);
            var tapaDto = new TapaDto
            {
                Schedule = "08:00,24:00;3,3"
            };

            var expected = new Schedule
            {
                Hours = string.Empty,
                Status = BusinessHoursConstants.ClosedToday,
            };

            //act
            var result = _businessHoursResolver.Resolve(tapaDto, _destination, _destMember, _context);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Hours, result.Hours);
            Assert.AreEqual(expected.Status, result.Status);
            Assert.IsFalse(result.Disable);
        }

        [TestMethod]
        public void Resolve_ValidBusinessHours_ReturnsOpeningSoonAndIsEnable()
        {
            //arrange
            var sundayMorning = new DateTime(2020, 6, 7, 11, 00, 00);
            _dateTimeWrapperMock.Setup(x => x.Now).Returns(sundayMorning);
            var tapaDto = new TapaDto
            {
                Schedule = "11:15,24:00;0,0"
            };

            var expected = new Schedule
            {
                Hours = "11:15-00:00",
                Status = BusinessHoursConstants.OpeningSoon,
            };

            //act
            var result = _businessHoursResolver.Resolve(tapaDto, _destination, _destMember, _context);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Hours, result.Hours);
            Assert.AreEqual(expected.Status, result.Status);
            Assert.IsFalse(result.Disable);
        }

        [TestMethod]
        public void Resolve_ValidBusinessHours_ReturnsClosingSoonAndIsEnable()
        {
            //arrange
            var sundayMorning = new DateTime(2020, 6, 7, 15, 45, 00);
            _dateTimeWrapperMock.Setup(x => x.Now).Returns(sundayMorning);
            var tapaDto = new TapaDto
            {
                Schedule = "10:45,16:00;0,0"
            };

            var expected = new Schedule
            {
                Hours = "10:45-16:00",
                Status = BusinessHoursConstants.ClosingSoon,
            };

            //act
            var result = _businessHoursResolver.Resolve(tapaDto, _destination, _destMember, _context);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Hours, result.Hours);
            Assert.AreEqual(expected.Status, result.Status);
            Assert.IsFalse(result.Disable);
        }
    }
}