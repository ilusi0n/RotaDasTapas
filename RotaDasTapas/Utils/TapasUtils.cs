using System.Collections.Generic;
using System.Linq;
using RotaDasTapas.Constants;
using RotaDasTapas.Models.Gateway;

namespace RotaDasTapas.Utils
{
    public static class TapasUtils
    {
        public static IEnumerable<TapaDto> InitMock()
        {
            var tapa1 = new TapaDto
            {
                Id = string.Join(Separators.Underscore, "Lisboa", 1),
                Name = "ZName1",
                Title = "Title1",
                Address = "Address",
                Description = "Description1",
                City = "Lisboa",
                ImageUrl = "https://b.zmtcdn.com/data/pictures/chains/9/18618109/fc91d7cf0ff3896fa3b6c4bd904ebd29.jpg"
            };
            var tapa2 = new TapaDto
            {
                Id = string.Join(Separators.Underscore, "Lisboa", 2),
                Name = "Name2",
                Title = "Title2",
                Address = "Address",
                Description = "Description2",
                City = "Lisboa",
                ImageUrl = "https://b.zmtcdn.com/data/pictures/chains/9/18618109/fc91d7cf0ff3896fa3b6c4bd904ebd29.jpg"
            };

            var tapa3 = new TapaDto
            {
                Id = string.Join(Separators.Underscore, "Lisboa", 3),
                Name = "Name3",
                Title = "Title3",
                Address = "Address",
                Description = "Description3",
                City = "Lisboa",
                ImageUrl = "https://b.zmtcdn.com/data/pictures/chains/9/18618109/fc91d7cf0ff3896fa3b6c4bd904ebd29.jpg"
            };
            
            var tapa4 = new TapaDto
            {
                Id = string.Join(Separators.Underscore, "Lisboa", 4),
                Name = "Name1",
                Title = "Title1",
                Address = "Address",
                Description = "Description1",
                City = "Lisboa",
                ImageUrl = "https://b.zmtcdn.com/data/pictures/chains/9/18618109/fc91d7cf0ff3896fa3b6c4bd904ebd29.jpg"
            };

            var tapa5 = new TapaDto
            {
                Id = string.Join(Separators.Underscore, "Porto", 1),
                Name = "Name1",
                Title = "Title1",
                Address = "Address",
                Description = "Description1",
                City = "Porto",
                ImageUrl = "https://b.zmtcdn.com/data/pictures/chains/9/18618109/fc91d7cf0ff3896fa3b6c4bd904ebd29.jpg"
            };

            tapa1.Path = new List<Path>
            {
                CreatePath(tapa1.Id, 0),
                CreatePath(tapa2.Id, 5),
                CreatePath(tapa3.Id, 1),
                CreatePath(tapa4.Id, 500)
            };
            tapa2.Path = new List<Path>
            {
                CreatePath(tapa1.Id, tapa1.Path.ToList()[1].Distance),
                CreatePath(tapa2.Id, 0),
                CreatePath(tapa3.Id, 40),
                CreatePath(tapa4.Id, 50)
            };
            tapa3.Path = new List<Path>
            {
                CreatePath(tapa1.Id, tapa1.Path.ToList()[2].Distance),
                CreatePath(tapa2.Id, tapa2.Path.ToList()[2].Distance),
                CreatePath(tapa3.Id, 0),
                CreatePath(tapa4.Id, 500)
            };
            tapa4.Path = new List<Path>
            {
                CreatePath(tapa1.Id, tapa1.Path.ToList()[3].Distance),
                CreatePath(tapa2.Id, tapa2.Path.ToList()[3].Distance),
                CreatePath(tapa3.Id, tapa3.Path.ToList()[3].Distance),
                CreatePath(tapa4.Id, 0)
            };
            tapa5.Path = new List<Path>
            {
                CreatePath(tapa1.Id, tapa1.Path.ToList()[3].Distance),
                CreatePath(tapa2.Id, tapa2.Path.ToList()[3].Distance),
                CreatePath(tapa3.Id, tapa3.Path.ToList()[3].Distance),
                CreatePath(tapa4.Id, 0)
            };

            return new List<TapaDto>
            {
                tapa1,
                tapa2,
                tapa3,
                tapa4
            };
        }

        private static Path CreatePath(string id, double distance)
        {
            return new Path
            {
                TapaId = id,
                Distance = distance
            };
        }

        public static IEnumerable<TapaDto> Init()
        {
            return new List<TapaDto>
            {
                new TapaDto
                {
                    Name = "Esquina",
                    Title = "Almondega à Esquina",
                    Address = "Praça Gomes Teixeira, nº26",
                    Description =
                        "Mini hamburger com bacon e queijo em bolo de caco da madeira, barrado com manteiga d'alho e ervas aromáticas",
                    City = "Lisboa",
                    ImageUrl = ""
                }
            };
        }
    }
}