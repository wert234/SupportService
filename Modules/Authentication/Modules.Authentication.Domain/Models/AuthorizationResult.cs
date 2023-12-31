using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Modules.Authentication.Domain.Models
{
    public class AuthorizationResult
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
