using System.Collections.Generic;
using RotaDasTapas.Models.Gateway;

namespace RotaDasTapas.Unit.Tests.Mocks
{
    public static class TapasGatewayMocks
    {
        public static IEnumerable<TapaDto> GetListOfTapasSingleOneWithAllFields()
        {
            return new List<TapaDto>
            {
                new TapaDto
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

        public static List<TapaDto> GetAllTapasWithPath()
        {
            return new List<TapaDto>
            {
                new TapaDto
                {
                    Id = "Lisbon_1",
                    Path = new List<Path>
                    {
                        new Path
                        {
                            TapaId = "Lisbon_1",
                            Distance = 0
                        },
                        new Path
                        {
                            TapaId = "Lisbon_2",
                            Distance = 10
                        },
                        new Path
                        {
                            TapaId = "Lisbon_3",
                            Distance = 20
                        }
                    }
                },
                new TapaDto
                {
                    Id = "Lisbon_2",
                    Path = new List<Path>
                    {
                        new Path
                        {
                            TapaId = "Lisbon_1",
                            Distance = 10
                        },
                        new Path
                        {
                            TapaId = "Lisbon_2",
                            Distance = 0
                        },
                        new Path
                        {
                            TapaId = "Lisbon_3",
                            Distance = 60
                        }
                    }
                },
                new TapaDto
                {
                    Id = "Lisbon_3",
                    Path = new List<Path>
                    {
                        new Path
                        {
                            TapaId = "Lisbon_1",
                            Distance = 20
                        },
                        new Path
                        {
                            TapaId = "Lisbon_2",
                            Distance = 60
                        },
                        new Path
                        {
                            TapaId = "Lisbon_3",
                            Distance = 0
                        }
                    }
                }
            };
        }
    }
}