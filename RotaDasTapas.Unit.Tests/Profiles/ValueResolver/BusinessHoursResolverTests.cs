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
        private BusinessHoursResolver _businessHoursResolver;
        private Mock<IDateTimeWrapper> _dateTimeWrapperMock;
        private ResolutionContext _context;
        private Tapa _destination;
        private Schedule _destMember;
        private Mock<IMappingOperationOptions> _mappingOperationOptions;
        private Mock<IRuntimeMapper> _runtimeMapperMock;
        public BusinessHoursResolverTests()
        {
            _dateTimeWrapperMock = new Mock<IDateTimeWrapper>();
            _businessHoursResolver = new BusinessHoursResolver(_dateTimeWrapperMock.Object);
            _runtimeMapperMock = new Mock<IRuntimeMapper>();
            _mappingOperationOptions = new Mock<IMappingOperationOptions>();
            _context = new ResolutionContext(_mappingOperationOptions.Object, _runtimeMapperMock.Object);
        }

        [TestMethod]
        public void Resolve_InvalidBusinessHours_ReturnsEmptyString()
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
            Assert.AreEqual(string.Empty,result.Hours);
            Assert.AreEqual(string.Empty,result.Status);
        }
        
        [TestMethod]
        public void Resolve_ValidBusinessHours_ReturnsOpen()
        {
            //arrange
            var sundayMorning = new DateTime(2019, 12, 22, 11, 00, 00);
            _dateTimeWrapperMock.Setup(x => x.Now).Returns(sundayMorning);
            var tapaDto = new TapaDto
            {
                Schedule = "08:00,24:00;0,6"
            };
            
            var expected  = new Schedule
            {
                Hours = "08:00-00:00",
                Status = BusinessHoursConstants.Open
            };
            
            //act
            var result = _businessHoursResolver.Resolve(tapaDto, _destination, _destMember, _context);
            
            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Hours,result.Hours);
            Assert.AreEqual(expected.Status,result.Status);
        }
        
        [TestMethod]
        public void Resolve_ValidBusinessHours_ReturnsClosed()
        {
            //arrange
            var sundayMorning = new DateTime(2019, 12, 22, 11, 00, 00);
            _dateTimeWrapperMock.Setup(x => x.Now).Returns(sundayMorning);
            var tapaDto = new TapaDto
            {
                Schedule = "08:00,24:00;3,3"
            };
            
            var expected  = new Schedule
            {
                Hours = string.Empty,
                Status = BusinessHoursConstants.Closed
            };
            
            //act
            var result = _businessHoursResolver.Resolve(tapaDto, _destination, _destMember, _context);
            
            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Hours,result.Hours);
            Assert.AreEqual(expected.Status,result.Status);
        }
    }
}