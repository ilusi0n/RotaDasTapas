using System.Collections.Generic;
using RotaDasTapas.Models;
using RotaDasTapas.Models.Gateway;

namespace RotaDasTapas.Unit.Tests.Mocks
{
    public static class TapasGatewayMocks
    {
        public static IEnumerable<TapaDto> GetListOfTapasSingleOneWithAllFields()
        {
            return new List<TapaDto>()
            {
                new TapaDto()
                {
                    Address = "address",
                    Description = "description",
                    Name = "name",
                    Title = "title",
                    City = "Lisboa"
                }
            };
        }

        public static TapaDto GetGetTapaAllFields()
        {
            return
                new TapaDto()
                {
                    Address = "address",
                    Description = "description",
                    Name = "name",
                    Title = "title"
                };
        }
    }
}