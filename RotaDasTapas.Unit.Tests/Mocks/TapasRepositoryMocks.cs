using System.Collections.Generic;
using RotaDasTapas.Models;

namespace RotaDasTapas.Unit.Tests.Mocks
{
    public static class TapasRepositoryMocks
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
                    Title = "title"
                }
            };
        }

        public static Tapa GetGetTapaAllFields()
        {
            return
                new Tapa()
                {
                    Address = "address",
                    Description = "description",
                    Name = "name",
                    Title = "title"
                };
        }
    }
}