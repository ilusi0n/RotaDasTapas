using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace RotaDasTapas.Models.Request
{
    public class RotaDasTapasHeaders
    {
        [FromHeader(Name = "ApiKey")]
        [Required]
        public string ApiKey { get; set; }
    }
}