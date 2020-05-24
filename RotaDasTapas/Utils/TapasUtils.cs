using System.Collections.Generic;
using RotaDasTapas.Models;
using RotaDasTapas.Models.Gateway;

namespace RotaDasTapas.Utils
{
    public static class TapasUtils
    {

        public static IEnumerable<TapaDto> InitMock()
        {
            return new List<TapaDto>()
            {
                new TapaDto
                {
                    Name = "ZName1",
                    Title = "Title1",
                    Address = "Address",
                    Description = "Description1",
                    City = "Lisboa"
                },
                new TapaDto
                {
                    Name = "Name1",
                    Title = "Title1",
                    Address = "Address",
                    Description = "Description1",
                    City = "Lisboa"
                },
                new TapaDto
                {
                    Name = "Name1",
                    Title = "Title1",
                    Address = "Address",
                    Description = "Description1",
                    City = "Lisboa"
                },
                new TapaDto
                {
                    Name = "Name1",
                    Title = "Title1",
                    Address = "Address",
                    Description = "Description1",
                    City = "Porto"
                }
            };
        }
        
        public static IEnumerable<TapaDto> Init()
        {
            return new List<TapaDto>()
            {
                new TapaDto
                {
                    Name = "Esquina",
                    Title = "Almondega à Esquina",
                    Address = "Praça Gomes Teixeira, nº26",
                    Description = "Mini hamburger com bacon e queijo em bolo de caco da madeira, barrado com manteiga d'alho e ervas aromáticas",
                    City = "Lisboa"
                }
            };
        }
    }
}