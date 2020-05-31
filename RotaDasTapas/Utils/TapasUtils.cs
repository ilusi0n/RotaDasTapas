using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RotaDasTapas.Constants;
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
                    Id = string.Join(Separators.Underscore,"Lisboa",1),
                    Name = "ZName1",
                    Title = "Title1",
                    Address = "Address",
                    Description = "Description1",
                    City = "Lisboa",
                    ImageUrl = "https://b.zmtcdn.com/data/pictures/chains/9/18618109/fc91d7cf0ff3896fa3b6c4bd904ebd29.jpg"
                },
                new TapaDto
                {
                    Id = string.Join(Separators.Underscore,"Lisboa",2),
                    Name = "Name2",
                    Title = "Title2",
                    Address = "Address",
                    Description = "Description2",
                    City = "Lisboa",
                    ImageUrl = "https://b.zmtcdn.com/data/pictures/chains/9/18618109/fc91d7cf0ff3896fa3b6c4bd904ebd29.jpg"
                },
                new TapaDto
                {
                    Id = string.Join(Separators.Underscore,"Lisboa",3),
                    Name = "Name3",
                    Title = "Title3",
                    Address = "Address",
                    Description = "Description3",
                    City = "Lisboa",
                    ImageUrl = "https://b.zmtcdn.com/data/pictures/chains/9/18618109/fc91d7cf0ff3896fa3b6c4bd904ebd29.jpg"
                },
                new TapaDto
                {
                    Id = string.Join(Separators.Underscore,"Porto",1),
                    Name = "Name1",
                    Title = "Title1",
                    Address = "Address",
                    Description = "Description1",
                    City = "Porto",
                    ImageUrl = "https://b.zmtcdn.com/data/pictures/chains/9/18618109/fc91d7cf0ff3896fa3b6c4bd904ebd29.jpg"
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
                    City = "Lisboa",
                    ImageUrl = ""
                }
            };
        }
    }
}