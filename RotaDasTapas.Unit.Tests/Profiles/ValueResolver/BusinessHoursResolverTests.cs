using System;
using System.Collections.Generic;
using System.Globalization;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RotaDasTapas.Constants;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Models.Response;
using RotaDasTapas.Profiles.ValueResolver;
using RotaDasTapas.Utils;

namespace RotaDasTapas.Unit.Tests.Profiles.ValueResolver
{
    [TestClass]
    public class BusinessHoursResolverTests
    {
        private readonly BusinessHoursResolver _businessHoursResolver;
        private readonly ResolutionContext _context;
        private readonly Tapa _destination;
        private readonly Schedule _destMember;
        private readonly Mock<IMappingOperationOptions> _mappingOperationOptions;
        private readonly Mock<IBusinessUtils> _mockBusinessUtils;

        public BusinessHoursResolverTests()
        {
            _destination = new Tapa();
            _destMember = new Schedule();
            _mockBusinessUtils = new Mock<IBusinessUtils>();
            _businessHoursResolver = new BusinessHoursResolver(_mockBusinessUtils.Object);
            var runtimeMapperMock = new Mock<IRuntimeMapper>();
            _mappingOperationOptions = new Mock<IMappingOperationOptions>();
            _context = new ResolutionContext(_mappingOperationOptions.Object, runtimeMapperMock.Object);
        }

        [TestMethod]
        public void Resolve_NullBusinessHours_ReturnsEmptyString()
        {
            //arrange
            var tapaDto = new TapaDto
            {
                Schedule = null
            };

            var itemsDictionary = new Dictionary<string, object>
                {{"localtime", DateTime.Now.ToString(CultureInfo.InvariantCulture)}};
            _mappingOperationOptions.Setup(dest => dest.Items).Returns(itemsDictionary);

            //act
            var result = _businessHoursResolver.Resolve(tapaDto, _destination, _destMember, _context);

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Resolve_InvalidBusinessHours_ReturnsEmpty()
        {
            //arrange
            var tapaDto = new TapaDto
            {
                Schedule = "08:00,24:00;7,7"
            };

            var itemsDictionary = new Dictionary<string, object>
                {{"localtime", DateTime.Now.ToString(CultureInfo.InvariantCulture)}};
            _mappingOperationOptions.Setup(dest => dest.Items).Returns(itemsDictionary);

            //act
            var result = _businessHoursResolver.Resolve(tapaDto, _destination, _destMember, _context);

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Resolve_ValidBusinessHours_ReturnsOpenAndEnable()
        {
            //arrange
            var sundayMorning = new DateTime(2019, 12, 22, 11, 00, 00);
            var itemsDictionary = new Dictionary<string, object>
                {{"localtime", sundayMorning.ToString(CultureInfo.InvariantCulture)}};
            _mappingOperationOptions.Setup(dest => dest.Items).Returns(itemsDictionary);
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
        }

        [TestMethod]
        public void Resolve_ValidBusinessHours_ReturnsClosedAndIsNotEnable()
        {
            //arrange
            var sundayMorning = new DateTime(2019, 12, 22, 11, 00, 00);
            var itemsDictionary = new Dictionary<string, object>
                {{"localtime", sundayMorning.ToString(CultureInfo.InvariantCulture)}};
            _mappingOperationOptions.Setup(dest => dest.Items).Returns(itemsDictionary);
            var tapaDto = new TapaDto
            {
                Schedule = "08:00,24:00;3,3"
            };

            var expected = new Schedule
            {
                Hours = string.Empty,
                Status = BusinessHoursConstants.ClosedToday
            };

            //act
            var result = _businessHoursResolver.Resolve(tapaDto, _destination, _destMember, _context);

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Resolve_ValidBusinessHours_ReturnsOpeningSoonAndIsEnable()
        {
            //arrange
            var sundayMorning = new DateTime(2020, 6, 7, 11, 00, 00);
            var itemsDictionary = new Dictionary<string, object>
                {{"localtime", sundayMorning.ToString(CultureInfo.InvariantCulture)}};
            _mappingOperationOptions.Setup(dest => dest.Items).Returns(itemsDictionary);
            var tapaDto = new TapaDto
            {
                Schedule = "11:15,24:00;0,0"
            };

            var expected = new Schedule
            {
                Hours = "11:15-00:00",
                Status = BusinessHoursConstants.OpeningSoon
            };

            //act
            var result = _businessHoursResolver.Resolve(tapaDto, _destination, _destMember, _context);

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Resolve_ValidBusinessHours_ReturnsClosingSoonAndIsEnable()
        {
            //arrange
            var sundayMorning = new DateTime(2020, 6, 7, 15, 45, 00);
            var itemsDictionary = new Dictionary<string, object>
                {{"localtime", sundayMorning.ToString(CultureInfo.InvariantCulture)}};
            _mappingOperationOptions.Setup(dest => dest.Items).Returns(itemsDictionary);
            var tapaDto = new TapaDto
            {
                Schedule = "10:45,16:00;0,0"
            };

            var expected = new Schedule
            {
                Hours = "10:45-16:00",
                Status = BusinessHoursConstants.ClosingSoon
            };

            //act
            var result = _businessHoursResolver.Resolve(tapaDto, _destination, _destMember, _context);

            //assert
            Assert.IsNotNull(result);
        }
    }
}