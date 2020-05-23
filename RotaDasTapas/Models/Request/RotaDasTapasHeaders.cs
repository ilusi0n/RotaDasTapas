using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace RotaDasTapas.Models.Request
{
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