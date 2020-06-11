using System;
using System.Globalization;
using System.Linq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RotaDasTapas.Constants;
using RotaDasTapas.Models.Request;
using RotaDasTapas.Models.Response;
using RotaDasTapas.Profiles;
using RotaDasTapas.Profiles.TypeConverter;
using RotaDasTapas.Profiles.ValueResolver;
using RotaDasTapas.Unit.Tests.Mocks;
using RotaDasTapas.Utils;

namespace RotaDasTapas.Unit.Tests.Profiles
{
    [TestClass]
    public class TapasResponseProfileTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBusinessHoursUtils> _mockBusinessUtils;

        public TapasResponseProfileTests()
        {
            _mockBusinessUtils = new Mock<IBusinessHoursUtils>();
            var serviceProvider = new Mock<IServiceProvider>();

            var configuration = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TapasResponseProfile());
                mc.ConstructServicesUsing(serviceProvider.Object.GetService);
            });

            _mapper = configuration.CreateMapper();

            serviceProvider.Setup(x => x.GetService(typeof(TapasResponseTypeConverter)))
                .Returns(new TapasResponseTypeConverter(_mapper));
            serviceProvider.Setup(x => x.GetService(typeof(BusinessHoursResolver)))
                .Returns(new BusinessHoursResolver(_mockBusinessUtils.Object));
        }

        [TestMethod]
        public void MapperConfiguration_ValidProfile_ConfigurationIsValid()
        {
            //Arrange
            var configuration = new MapperConfiguration(cfg => { cfg.AddProfile<TapasResponseProfile>(); });
            configuration.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void MapTapaDtoToTapasResponse_ValidModel_ReturnNotNullAllParametersAreEqual()
        {
            //Arrange
            var rotaDasTapasParameters = new TapasParameters
            {
                Localtime = DateTime.Now.ToString(CultureInfo.InvariantCulture)
            };
            var tapaDto = TapasGatewayMocks.GetGetTapaAllFields();
            var expected = new TapasResponse
            {
                Tapas =
                    TapasServiceMocks.GetGetTapaAllFields()
            };

            _mockBusinessUtils.Setup(el => el.GetStatus()).Returns(BusinessHoursConstants.Open);
            _mockBusinessUtils.Setup(el => el.GetCurrentSchedule()).Returns("12:30-13:00");

            //Act
            var result = _mapper.Map<TapasResponse>(tapaDto,
                options => options.Items["localtime"] = rotaDasTapasParameters.Localtime);

            //Assert
            AssertAllFields(expected, result);
        }

        [TestMethod]
        public void MapIEnumerableTapaDtoToTapasResponse_ValidModel_ReturnNotNullAllParametersAreEqual()
        {
            //Arrange
            var rotaDasTapasParameters = new TapasParameters
            {
                Localtime = DateTime.Now.ToString(CultureInfo.InvariantCulture)
            };
            var listTapasDto = TapasGatewayMocks.GetListOfTapasSingleOneWithAllFields();
            var expected = new TapasResponse
            {
                Tapas = TapasServiceMocks.GetListOfTapasSingleOneWithAllFields()
            };

            _mockBusinessUtils.Setup(el => el.GetStatus()).Returns(BusinessHoursConstants.Open);
            _mockBusinessUtils.Setup(el => el.GetCurrentSchedule()).Returns("12:30-13:30");

            //Act
            var result = _mapper.Map<TapasResponse>(listTapasDto,
                options => options.Items["localtime"] = rotaDasTapasParameters.Localtime);

            //Assert
            AssertAllFields(expected, result);
        }

        private void AssertAllFields(TapasResponse expected, TapasResponse result)
        {
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Tapas);
            Assert.AreEqual(expected.Tapas.Count(), result.Tapas.Count());
            var nExpected = 0;
            foreach (var exp in expected.Tapas)
            {
                Assert.AreEqual(exp.Address, result.Tapas.ToList()[nExpected].Address);
                Assert.AreEqual(exp.City, result.Tapas.ToList()[nExpected].City);
                Assert.AreEqual(exp.Description, result.Tapas.ToList()[nExpected].Description);
                Assert.AreEqual(exp.Name, result.Tapas.ToList()[nExpected].Name);
                Assert.AreEqual(exp.Title, result.Tapas.ToList()[nExpected].Title);
                Assert.AreEqual(exp.City, result.Tapas.ToList()[nExpected].City);
                Assert.IsNotNull(result.Tapas.ToList()[nExpected].Schedule);
                Assert.IsNotNull(result.Tapas.ToList()[nExpected].Schedule.Hours);
                Assert.IsNotNull(result.Tapas.ToList()[nExpected].Schedule.Status);
                nExpected++;
            }
        }
    }
}