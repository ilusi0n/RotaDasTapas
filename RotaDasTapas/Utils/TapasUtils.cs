using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using RotaDasTapas.Constants;
using RotaDasTapas.Models.Gateway;

namespace RotaDasTapas.Utils
{
    [ExcludeFromCodeCoverage]
    public static class TapasUtils
    {
        public static IEnumerable<TapaDto> InitMock()
        {
            var LisboaTapa1 = new TapaDto
            {
                Id = string.Join(Separators.Underscore, "Lisbon", 1),
                Name = "Red",
                Title = "Tiborna de Rosbife",
                Address = "Praça São João Bosco, nº554",
                Description = "Rosbife, pão, batata-doce com bacon ou cogumelos",
                City = "Lisbon",
                ImageUrl =
                    "https://b.zmtcdn.com/data/reviews_photos/457/3a067bf6486868b3e5f4691067e39457_1506688864.jpg",
                Schedule = "15:00,21:00;1,5|12:00,21:30;0,0|12:00,21:30;6,6"
            };
            var LisboaTapa2 = new TapaDto
            {
                Id = string.Join(Separators.Underscore, "Lisbon", 2),
                Name = "Verde Gaio",
                Title = "Tapa do Chef",
                Address = "Rua Francisco Metrass, nº18, B",
                Description = "Farinheira assada na brasa com alface francesa",
                City = "Lisbon",
                ImageUrl =
                    "https://b.zmtcdn.com/data/reviews_photos/3d8/f9db351dec4e65052a00f9e0364d13d8_1491355337.jpg",
                Schedule = "13:00,23:00;1,6"
            };

            var LisboaTapa3 = new TapaDto
            {
                Id = string.Join(Separators.Underscore, "Lisbon", 3),
                Name = "Choco do Bairro",
                Title = "Choco à Pescador",
                Address = "Rua Tenente Ferreira Durão, Nº 55, A",
                Description = "Guisado de Choco, acompanhado com pão dourado e coentros",
                City = "Lisbon",
                ImageUrl =
                    "https://b.zmtcdn.com/data/reviews_photos/b30/49a3e35fe3e566cd8b1fcda57bf94b30_1545936190.jpg",
                Schedule = "18:00,21:30;1,6"
            };

            var LisboaTapa4 = new TapaDto
            {
                Id = string.Join(Separators.Underscore, "Lisbon", 4),
                Name = "Pigmeu",
                Title = "Oinki Satay",
                Address = "Rua 4 de Infantaria, nº68",
                Description = "Espetadinha de cachaço marinada em Estrella Damm e grelhada com molho de amendoim",
                City = "Lisbon",
                ImageUrl = "https://b.zmtcdn.com/data/pictures/chains/1/8211481/3ed9649189f68527a20c9c8aba75ea51.jpg",
                Schedule = "12:30,14:30;2,6|12:30,14:30;0,0|18:45,22:30;2,6|18:45,22:30;0,0"
            };

            var LisboaTapa5 = new TapaDto
            {
                Id = string.Join(Separators.Underscore, "Lisbon", 5),
                Name = "Moulles & Beer",
                Title = "Mexilhão Panado",
                Address = "Rua 4 de Infantaria, Nº29, B",
                Description = "Mexilhão panado com molho de sweet, chilli e maionese",
                City = "Lisbon",
                ImageUrl = "https://b.zmtcdn.com/data/pictures/4/8201164/44384b8b6643e6c988f71c1fc7071544.jpg",
                Schedule = "19:00,23:00;0,6"
            };

            var LisboaTapa6 = new TapaDto
            {
                Id = string.Join(Separators.Underscore, "Lisbon", 6),
                Name = "Pequeno Reino",
                Title = "Quibes Vegetarianos de Lentilhas",
                Address = "Rua 4 de Infantaria, Nº32, A",
                Description = "Porção de quatro quibes de lentihas fritos",
                City = "Lisbon",
                ImageUrl =
                    "https://b.zmtcdn.com/data/reviews_photos/873/45fb4c16be35545f40c6e209df0f5873_1514990123.jpg",
                Schedule = "15:00,21:00;2,6|15:00,21:00;0,0"
            };

            var PortoTapa1 = new TapaDto
            {
                Id = string.Join(Separators.Underscore, "Porto", 1),
                Name = "Name1",
                Title = "Title1",
                Address = "Address",
                Description = "Description1",
                City = "Porto",
                ImageUrl = "https://b.zmtcdn.com/data/pictures/chains/9/18618109/fc91d7cf0ff3896fa3b6c4bd904ebd29.jpg",
                Schedule = "07:00,15:00;1,1|07:00,14:00;6,6"
            };

            LisboaTapa1.Path = new List<Path>
            {
                CreatePath(LisboaTapa1.Id, 0),
                CreatePath(LisboaTapa2.Id, 5),
                CreatePath(LisboaTapa3.Id, 1),
                CreatePath(LisboaTapa4.Id, 500),
                CreatePath(LisboaTapa5.Id, 200),
                CreatePath(LisboaTapa6.Id, 120)
            };
            LisboaTapa2.Path = new List<Path>
            {
                CreatePath(LisboaTapa1.Id, LisboaTapa1.Path.ToList()[1].Distance),
                CreatePath(LisboaTapa2.Id, 0),
                CreatePath(LisboaTapa3.Id, 40),
                CreatePath(LisboaTapa4.Id, 50),
                CreatePath(LisboaTapa5.Id, 300),
                CreatePath(LisboaTapa6.Id, 520)
            };
            LisboaTapa3.Path = new List<Path>
            {
                CreatePath(LisboaTapa1.Id, LisboaTapa1.Path.ToList()[2].Distance),
                CreatePath(LisboaTapa2.Id, LisboaTapa2.Path.ToList()[2].Distance),
                CreatePath(LisboaTapa3.Id, 0),
                CreatePath(LisboaTapa4.Id, 500),
                CreatePath(LisboaTapa5.Id, 700),
                CreatePath(LisboaTapa6.Id, 220)
            };
            LisboaTapa4.Path = new List<Path>
            {
                CreatePath(LisboaTapa1.Id, LisboaTapa1.Path.ToList()[3].Distance),
                CreatePath(LisboaTapa2.Id, LisboaTapa2.Path.ToList()[3].Distance),
                CreatePath(LisboaTapa3.Id, LisboaTapa3.Path.ToList()[3].Distance),
                CreatePath(LisboaTapa4.Id, 0),
                CreatePath(LisboaTapa5.Id, 800),
                CreatePath(LisboaTapa6.Id, 1220)
            };
            LisboaTapa5.Path = new List<Path>
            {
                CreatePath(LisboaTapa1.Id, LisboaTapa1.Path.ToList()[4].Distance),
                CreatePath(LisboaTapa2.Id, LisboaTapa2.Path.ToList()[4].Distance),
                CreatePath(LisboaTapa3.Id, LisboaTapa3.Path.ToList()[4].Distance),
                CreatePath(LisboaTapa4.Id, LisboaTapa3.Path.ToList()[4].Distance),
                CreatePath(LisboaTapa5.Id, 0),
                CreatePath(LisboaTapa6.Id, 6520)
            };
            LisboaTapa6.Path = new List<Path>
            {
                CreatePath(LisboaTapa1.Id, LisboaTapa1.Path.ToList()[5].Distance),
                CreatePath(LisboaTapa2.Id, LisboaTapa2.Path.ToList()[5].Distance),
                CreatePath(LisboaTapa3.Id, LisboaTapa3.Path.ToList()[5].Distance),
                CreatePath(LisboaTapa4.Id, LisboaTapa3.Path.ToList()[5].Distance),
                CreatePath(LisboaTapa5.Id, LisboaTapa3.Path.ToList()[5].Distance),
                CreatePath(LisboaTapa6.Id, 0)
            };

            return new List<TapaDto>
            {
                LisboaTapa1,
                LisboaTapa2,
                LisboaTapa3,
                LisboaTapa4,
                LisboaTapa5,
                LisboaTapa6
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