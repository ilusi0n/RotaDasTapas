using System.Collections.Generic;
using RotaDasTapas.Models;

namespace RotaDasTapas.Utils
{
    public static class TapasUtils
    {

        public static IEnumerable<Tapa> InitMock()
        {
            return new List<Tapa>()
            {
                new Tapa
                {
                    Name = "Name1",
                    Title = "Title1",
                    Address = "Address",
                    Description = "Description1",
                    City = "Lisboa"
                },
                new Tapa
                {
                    Name = "Name1",
                    Title = "Title1",
                    Address = "Address",
                    Description = "Description1",
                    City = "Lisboa"
                },
                new Tapa
                {
                    Name = "Name1",
                    Title = "Title1",
                    Address = "Address",
                    Description = "Description1",
                    City = "Lisboa"
                },
                new Tapa
                {
                    Name = "Name1",
                    Title = "Title1",
                    Address = "Address",
                    Description = "Description1",
                    City = "Porto"
                }
            };
        }
        
        public static IEnumerable<Tapa> Init()
        {
            return new List<Tapa>()
            {
                new Tapa
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