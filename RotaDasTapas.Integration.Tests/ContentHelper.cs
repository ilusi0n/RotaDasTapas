using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace RotaDasTapas.Integration.Tests
{
    [ExcludeFromCodeCoverage]
    public static class ContentHelper
    {
        public static StringContent GetStringContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");
        }
    }
}