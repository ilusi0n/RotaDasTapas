using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;

namespace RotaDasTapas.Models.Request
{
    [ExcludeFromCodeCoverage]
    public class RotaDasTapasHeaders
    {
        /// <summary>
        ///     ApiKey to access the API
        /// </summary>
        [FromHeader(Name = "ApiKey")]
        [Required]
        public string ApiKey { get; set; }
    }
}