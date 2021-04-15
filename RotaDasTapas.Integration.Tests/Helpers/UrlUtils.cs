using System.Net.Http;
using System.Threading.Tasks;
using RotaDasTapas.Models.Request;

namespace RotaDasTapas.Integration.Tests.Helpers
{
    public static class UrlUtils
    {
        public static async Task<string> BuildUrlWithParameters(TapasParameters model)
        {
            var keyValues = model.ToKeyValue();
            var content = new FormUrlEncodedContent(keyValues);
            return await content.ReadAsStringAsync();
        }
    }
}