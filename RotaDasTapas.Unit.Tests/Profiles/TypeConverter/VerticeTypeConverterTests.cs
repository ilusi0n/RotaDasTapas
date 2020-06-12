using System;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RotaDasTapas.Models.Gateway;
using RotaDasTapas.Models.Response;
using RotaDasTapas.Models.TSP;
using RotaDasTapas.Profiles.TypeConverter;

namespace RotaDasTapas.Unit.Tests.Profiles.TypeConverter
{
    [TestClass]
    public class VerticeTypeConverterTests
    {
        private readonly ResolutionContext _context;
        private readonly Mock<IMapper> _mockMapper;
        private readonly VerticeTypeConverter _verticeTypeConverter;

        public VerticeTypeConverterTests()
        {
            _mockMapper = new Mock<IMapper>();
            _verticeTypeConverter = new VerticeTypeConverter(_mockMapper.Object);
            var runtimeMapperMock = new Mock<IRuntimeMapper>();
            var mappingOperationOptions = new Mock<IMappingOperationOptions>();
            _context = new ResolutionContext(mappingOperationOptions.Object, runtimeMapperMock.Object);
        }

        [TestMethod]
        public void Resolve_Vertice_ReturnsTapaDto()
        {
            //arrange
            var vertice = new Vertice
            {
                TapaDto = new TapaDto()
            };
            var tapa = new Tapa();

            _mockMapper.Setup(m =>
                    m.Map<Tapa>(It.IsAny<TapaDto>(),
                        It.IsAny<Action<IMappingOperationOptions>>()))
                .Returns(tapa);

            //act
            var result = _verticeTypeConverter.Convert(vertice, new Tapa(), _context);

            //assert
            Assert.IsNotNull(result);
        }
    }
}