using System.Collections.Generic;
using RotaDasTapas.Constants;
using RotaDasTapas.Models;
using RotaDasTapas.Models.Response;

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