using System;
using System.Diagnostics.CodeAnalysis;

namespace RotaDasTapas.Models.Models
{
    [ExcludeFromCodeCoverage]
    public class DateTimeWrapper : IDateTimeWrapper
    {
        public DateTime Now => DateTime.UtcNow;
    }
}