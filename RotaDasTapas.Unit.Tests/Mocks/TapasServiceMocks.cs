using System.Collections.Generic;
using RotaDasTapas.Models;

namespace RotaDasTapas.Unit.Tests.Mocks
{
    public class TapasServiceMocks
    {
        public static IEnumerable<Tapa> GetListOfTapasSingleOneWithAllFields()
        {
            return new List<Tapa>()
            {
                new Tapa()
                {
                    Address = "address",
                    Description = "description",
                    Name = "name",
                    Title = "title",
                    City = "Lisboa"
                }
            };
        }

        public static IEnumerable<Tapa> GetGetTapaAllFields()
        {
            return new List<Tapa>
            {
                new Tapa
                {
                    Address = "address",
                    Description = "description",
                    Name = "name",
                    Title = "title"
                }
            };
        }
    }
}