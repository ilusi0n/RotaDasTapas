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
                new TapaDto
                {
                    Id = "Id_lisboa",
                    Address = "address",
                    Description = "description",
                    Name = "name",
                    Title = "title",
                    ImageUrl = "imageurl",
                    City = "city",
                    Schedule = "08:00,24:00;0,6"
                };
        }
    }
}