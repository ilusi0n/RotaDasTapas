using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using RotaDasTapas.Constants;
using RotaDasTapas.Models.Response;

namespace RotaDasTapas.Unit.Tests.Mocks
{
    [ExcludeFromCodeCoverage]
    public static class TapasServiceMocks
    {
        public static TapasResponse GetAllTapas()
        {
            return new TapasResponse
            {
                Tapas = new List<Tapa>
                {
                    new Tapa
                    {
                        Id = "Lisbon_1",
                        Name = "Red",
                        Title = "Tiborna de Rosbife",
                        Address = "Praça São João Bosco, nº554",
                        Description = "Rosbife, pão, batata-doce com bacon ou cogumelos",
                        City = "Lisbon",
                        ImageUrl =
                            "https://b.zmtcdn.com/data/reviews_photos/457/3a067bf6486868b3e5f4691067e39457_1506688864.jpg",
                        Schedule = new Schedule
                        {
                            Hours = "15:00-21:00",
                            Status = "Open",
                        }
                    },
                    new Tapa
                    {
                        Id = "Lisbon_2",
                        Name = "Verde Gaio",
                        Title = "Tapa do Chef",
                        Address = "Rua Francisco Metrass, nº18, B",
                        Description = "Farinheira assada na brasa com alface francesa",
                        City = "Lisbon",
                        ImageUrl =
                            "https://b.zmtcdn.com/data/reviews_photos/3d8/f9db351dec4e65052a00f9e0364d13d8_1491355337.jpg",
                        Schedule = new Schedule
                        {
                            Hours = "13:00-23:00",
                            Status = "Open",
                        }
                    },
                    new Tapa
                    {
                        Id = "Lisbon_3",
                        Name = "Choco do Bairro",
                        Title = "Choco à Pescador",
                        Address = "Rua Tenente Ferreira Durão, Nº 55, A",
                        Description = "Guisado de Choco, acompanhado com pão dourado e coentros",
                        City = "Lisbon",
                        ImageUrl =
                            "https://b.zmtcdn.com/data/reviews_photos/b30/49a3e35fe3e566cd8b1fcda57bf94b30_1545936190.jpg",
                        Schedule = new Schedule
                        {
                            Hours = "18:00-21:30",
                            Status = "Open",
                        }
                    },
                    new Tapa
                    {
                        Id = "Lisbon_4",
                        Name = "Pigmeu",
                        Title = "Oinki Satay",
                        Address = "Rua 4 de Infantaria, nº68",
                        Description =
                            "Espetadinha de cachaço marinada em Estrella Damm e grelhada com molho de amendoim",
                        City = "Lisbon",
                        ImageUrl =
                            "https://b.zmtcdn.com/data/pictures/chains/1/8211481/3ed9649189f68527a20c9c8aba75ea51.jpg",
                        Schedule = new Schedule
                        {
                            Hours = "12:30-14:30",
                            Status = "Closed",
                        }
                    },
                    new Tapa
                    {
                        Id = "Lisbon_5",
                        Name = "Moulles & Beer",
                        Title = "Mexilhão Panado",
                        Address = "Rua 4 de Infantaria, Nº29, B",
                        Description = "Mexilhão panado com molho de sweet, chilli e maionese",
                        City = "Lisbon",
                        ImageUrl = "https://b.zmtcdn.com/data/pictures/4/8201164/44384b8b6643e6c988f71c1fc7071544.jpg",
                        Schedule = new Schedule
                        {
                            Hours = "19:00-23:00",
                            Status = "Closed",
                        }
                    },
                    new Tapa
                    {
                        Id = "Lisbon_6",
                        Name = "Pequeno Reino",
                        Title = "Quibes Vegetarianos de Lentilhas",
                        Address = "Rua 4 de Infantaria, Nº32, A",
                        Description = "Porção de quatro quibes de lentihas fritos",
                        City = "Lisbon",
                        ImageUrl =
                            "https://b.zmtcdn.com/data/reviews_photos/873/45fb4c16be35545f40c6e209df0f5873_1514990123.jpg",
                        Schedule = new Schedule
                        {
                            Hours = "15:00-21:00",
                            Status = "Open",
                        }
                    }
                }
            };
        }


        public static IEnumerable<Tapa> GetListOfTapasSingleOneWithAllFields()
        {
            return new List<Tapa>
            {
                new Tapa
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
                    Id = "Id_lisboa",
                    Address = "address",
                    Description = "description",
                    Name = "name",
                    Title = "title",
                    City = "city",
                    Schedule = new Schedule
                    {
                        Hours = "08:00-00:00",
                        Status = BusinessHoursConstants.Open
                    }
                }
            };
        }
    }
}