using System;
using System.Globalization;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RotaDasTapas.Constants;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Models.Request;
using RotaDasTapas.Models.Response;
using RotaDasTapas.Models.TSP;
using RotaDasTapas.Profiles;
using RotaDasTapas.Profiles.TypeConverter;
using RotaDasTapas.Profiles.ValueResolver;
using RotaDasTapas.Utils;

namespace RotaDasTapas.Unit.Tests.Profiles
{
    [TestClass]
    public class VerticeProfileTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBusinessHoursUtils> _mockBusinessUtils;

        public VerticeProfileTests()
        {
            _mockBusinessUtils = new Mock<IBusinessHoursUtils>();
            var serviceProvider = new Mock<IServiceProvider>();
            var configuration = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new VerticeProfile());
                mc.ConstructServicesUsing(serviceProvider.Object.GetService);
            });

            _mapper = configuration.CreateMapper();
            serviceProvider.Setup(x => x.GetService(typeof(VerticeTypeConverter)))
                .Returns(new VerticeTypeConverter(_mapper));
            serviceProvider.Setup(x => x.GetService(typeof(BusinessHoursResolver)))
                .Returns(new BusinessHoursResolver(_mockBusinessUtils.Object));
        }

        [TestMethod]
        public void MapperConfiguration_ValidProfile_ConfigurationIsValid()
        {
            //Arrange
            var configuration = new MapperConfiguration(cfg => { cfg.AddProfile<VerticeProfile>(); });
            configuration.AssertConfigurationIsValid();
        }

        public void MapVerticeToTapa_ValidModel_ReturnNotNullAllParametersAreEqual()
        {
            //Arrange
            var rotaDasTapasParameters = new TapasParameters
            {
                Localtime = DateTime.Now.ToString(CultureInfo.InvariantCulture)
            };

            var vertice = new Vertice
            {
                TapaDto = new TapaDto
                {
                    Id = "Lisboa_1"
                }
            };

            var expected = new Tapa
            {
                Id = "Lisboa_1"
            };

            _mockBusinessUtils.Setup(el => el.GetStatus()).Returns(BusinessHoursConstants.Open);
            _mockBusinessUtils.Setup(el => el.GetCurrentSchedule()).Returns("12:30-13:00");

            //Act
            var result = _mapper.Map<Tapa>(vertice,
                options => options.Items["localtime"] = rotaDasTapasParameters.Localtime);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Id, result.Id);
        }
    }
}